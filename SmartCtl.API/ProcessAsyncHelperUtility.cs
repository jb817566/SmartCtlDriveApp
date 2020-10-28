using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCtlDriveWebApp.Controllers
{
    public static class ProcessAsyncHelperUtility
    {
        public static async Task<StringBuilder> ExecuteShellCommand(string command, string arguments, string tag, string workingDir = null,
            string[] quitLines = null, bool silent = true)
        {
            System.Console.WriteLine($"--------\n{command} {arguments}\n    ----------");
            StringBuilder outputBuilder = new StringBuilder();
            using (Process process = new Process())
            {
                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                if (workingDir != null)
                {
                    process.StartInfo.WorkingDirectory = workingDir;
                }

                TaskCompletionSource<bool> outputCloseEvent = new TaskCompletionSource<bool>();

                process.OutputDataReceived += (s, e) =>
                {
                    // The output stream has been closed i.e. the process has terminated
                    if (e.Data == null)
                    {
                        outputCloseEvent.SetResult(true);
                    }
                    else
                    {
                        if (!silent)
                        {
                            System.Console.WriteLine($"{tag}{e.Data}");
                        }

                        outputBuilder.AppendLine(e.Data);
                        if (quitLines != null)
                        {
                            if (quitLines.Any(q => e.Data.Contains((string)q)))
                            {
                                if (!silent)
                                    System.Console.Error.WriteLine("HTTP Error 429 Download Limit Reached");
                                Environment.Exit(1);
                            }
                        }
                    }
                };

                StringBuilder errorBuilder = new StringBuilder();
                TaskCompletionSource<bool> errorCloseEvent = new TaskCompletionSource<bool>();

                process.ErrorDataReceived += (s, e) =>
                {
                    // The error stream has been closed i.e. the process has terminated
                    if (e.Data == null)
                    {
                        errorCloseEvent.SetResult(true);
                    }
                    else
                    {
                        if (!silent)
                            System.Console.WriteLine($"CONSOLE ERROR: {tag}{e.Data}");
                        outputBuilder.AppendLine(e.Data);
                        if (quitLines != null)
                        {
                            if (quitLines.Any(q => e.Data.Contains(q)))
                            {
                                System.Console.Error.WriteLine("HTTP Error 429 Download Limit Reached");
                                Environment.Exit(1);
                            }
                        }
                    }
                };

                bool isStarted = default;
                try
                {
                    isStarted = process.Start();
                }
                catch (Exception error)
                {
                    // Usually it occurs when an executable file is not found or is not executable
                    if (!silent)
                    {
                        System.Console.WriteLine(error.Message);
                        System.Console.WriteLine(error.StackTrace);
                    }

                    isStarted = false;
                }

                if (isStarted)
                {
                    // Reads the output stream first and then waits because deadlocks are possible
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    // Creates task to wait for process exit using timeout
                    Task<bool> waitForExit = WaitForExitAsync(process, int.MaxValue);

                    // Create task to wait for process exit and closing all output streams
                    Task<bool[]> processTask = Task.WhenAll(waitForExit, outputCloseEvent.Task, errorCloseEvent.Task);

                    // Waits process completion and then checks it was not completed by timeout
                    if (await Task.WhenAny(Task.Delay(int.MaxValue), processTask) == processTask && waitForExit.Result)
                    {
                        if (!silent)
                            System.Console.WriteLine("Success");
                    }
                    else
                    {
                        try
                        {
                            // Kill hung process
                            process.Kill();
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return outputBuilder;
        }


        private static Task<bool> WaitForExitAsync(Process process, int timeout)
        {
            return Task.Run(() => process.WaitForExit(timeout));
        }


    }
}