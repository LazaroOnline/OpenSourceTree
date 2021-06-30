using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace OpenSourceTreeUI
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OpenSourceTree_Click(object sender, RoutedEventArgs e)
		{
			OpenSourceTree(this.TxtRepoPath.Text);
		}

		private void OpenSourceTreeFromClipboard_Click(object sender, RoutedEventArgs e)
		{
			this.TxtRepoPath.Text = Clipboard.GetText(TextDataFormat.Text);
			OpenSourceTree(this.TxtRepoPath.Text);
		}

		public void OpenSourceTree(string repoDirPath)
		{
			// Command example:
			// "C:\Users\your.windows.username\AppData\Local\SourceTree\app-3.4.5\SourceTree.exe" -f "C:\some-folder\your-repo-folder"

			var sourceTreeExeFullPath = ConfigurationManager.AppSettings["SourceTreeExePath"];

			var command = $@"{sourceTreeExeFullPath} -f ""{repoDirPath}""";
			Console.WriteLine(command);
			Debug.WriteLine(command);

			try
			{
				var output = RunCmd(command);
				TxtLog.Text = output;
			}
			catch (CmdException ex)
			{
				TxtLog.Text = $"{ex.GetType()}{Environment.NewLine}{ex.Message}{Environment.NewLine}Command: {ex.command}";
			}
		}

		public string RunCmd(string command, string workingDir = "")
		{
			var startInfo = new ProcessStartInfo()
			{
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				FileName = "CMD.exe",
				Arguments = @"/c " + command,
				WorkingDirectory = workingDir,
			};
			
			var process = Process.Start(startInfo);
			string output = process.StandardOutput.ReadToEnd();
			string outputError = process.StandardError.ReadToEnd();
			var hasErrors = !string.IsNullOrEmpty(outputError);
			if (hasErrors) {
				throw new CmdException(outputError) { command = command};
			}
			return output;
		}

	}
}
