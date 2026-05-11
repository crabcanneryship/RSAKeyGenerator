using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeyGenerator
{
    public partial class MainForm : Form
    {
        // Constants
        const int MAX_PATH_LENGTH = 260; // Paths longer than this may not be visible in Explorer.
        const int KEY_SIZE = 4096; // RSA key size

        /// <summary>
        /// Initializer
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            txtDestination.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txtDestination.SelectionStart = txtDestination.Text.Length;
        }

        /// <summary>
        /// browse button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Open Folder Browser Dialog and get result if ResultOK
            if (DialogResult.OK == fbdDestination.ShowDialog())
            {
                // Set the result to the TextBox
                txtDestination.Text = fbdDestination.SelectedPath;
            }
        }

        /// <summary>
        /// Generate button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Error collection
            List<string> errors = new List<string>();

            // Existing file collection
            List<string> existingFiles = new List<string>();


            // Save input as valuables
            string destination = txtDestination.Text;
            string privateName = txtPrivate.Text;
            string privatePath = Path.Combine(destination, privateName);
            string publicName = txtPublic.Text;
            string publicPath = Path.Combine(destination, publicName);

            // Validation Check
            if (destination.Length == 0)
            {
                errors.Add("Specify the destination directory.");
            }
            else if (!Directory.Exists(destination))
            {
                errors.Add("The destination directory doesn't exist.");
            }
            if (privateName.Length == 0)
            {
                errors.Add("Specify the private key filename.");
            }
            else if (!IsValidFileName(privateName))
            {
                errors.Add("Private key name seems to have invalid charachter(s). Please check.");
            }
            else if (privatePath.Length > MAX_PATH_LENGTH)
            {
                errors.Add("Private key path looks too long.");
            }
            else if (File.Exists(privatePath))
            {
                existingFiles.Add(privateName);
            }
            if (publicName.Length == 0)
            {
                errors.Add("Specify the public key filename.");
            }
            else if (privateName.Equals(publicName))
            {
                errors.Add("Private Key and Public Key must have different filenames.");
            }
            else if (!IsValidFileName(publicName))
            {
                errors.Add("Public key name seems to have invalid charachter(s). Please check.");
            }
            else if (publicPath.Length > MAX_PATH_LENGTH)
            {
                errors.Add("Public key path looks too long.");
            }
            else if (File.Exists(publicPath))
            {
                existingFiles.Add(publicName);
            }

            // Show error message(s) and exit 
            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join('\n', errors), "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Alert file existence and quit the process if user wouldn't like to proceed
            if (existingFiles.Count > 0)
            {
                string names = string.Join(", ", existingFiles);
                if (DialogResult.Yes != MessageBox.Show(
                    $"\"{names}\" already exists. Is it OK to overwrite?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
            }

            // Generate RSA keys
            try
            {
                using (RSA rsa = RSA.Create(KEY_SIZE))
                {
                    // private
                    File.WriteAllText(privatePath, rsa.ExportPkcs8PrivateKeyPem());

                    // public
                    File.WriteAllText(publicPath, rsa.ExportSubjectPublicKeyInfoPem());
                }

                // If nothing happan, show completion
                MessageBox.Show("Key files have been generated.",
                    "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show exception message
                MessageBox.Show($"Something went wrong:\n{ex.Message}",
                    "Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Check FileName Validities
        /// </summary>
        /// <param name="fileName">File name to be checked</param>
        /// <returns>Valid or not</returns>
        private bool IsValidFileName(string fileName)
        {
            // Check basic prohibited chars
            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                return false;

            // Check reserved name
            string reservedPattern = @"^(?i)(CON|PRN|AUX|NUL|COM[1-9]|LPT[1-9])(\..*)?$";
            if (Regex.IsMatch(fileName, reservedPattern))
                return false;

            // Check . or space ending
            if (fileName.EndsWith(" ") || fileName.EndsWith("."))
                return false;

            return true;
        }
    }
}
