using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AMModInstaller
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            var user = SystemInformation.UserName.ToString();
            label1.Text = "AMModInstaller, Hello " + user + "!";

            listBox1.Items.Clear();

            label5.Text = " ";

            var EXELoc = Directory.GetCurrentDirectory();

            if (Directory.Exists(EXELoc + "/ModFolder"))
            {
                label4.Hide();

                var ModFolder = EXELoc + "/ModFolder";

                var ModFolderMods = Directory.GetFiles(ModFolder, "*.*", SearchOption.TopDirectoryOnly);

                foreach (var mod in ModFolderMods)
                {
                    listBox1.Items.Add(Path.GetFileNameWithoutExtension(mod));
                }
            }
            else
            {
                label4.Show();

                label5.Hide();
            }

            if (File.Exists(EXELoc + "/AM_DLoc.Location"))
            {
                var PrevLoc = File.ReadAllText(EXELoc + "/AM_DLoc.Location");

                if (Directory.Exists(PrevLoc))
                {
                    label2.Text = "Valid previous location found.\nYou can still edit it by typing a new location in the text box below.";

                    textBox1.Text = PrevLoc;
                }
                else
                {
                    label2.Text = "A directory was previously entered which does not currently exist.\nPlease type a correct directory below.";
                }
            }

            if (Directory.Exists(EXELoc + "/Preferences"))
            {

            }
            {
                Directory.CreateDirectory(EXELoc + "/Preferences");
            }

            if (File.Exists(EXELoc + "/Preferences/SAUOMI.AMMIPref"))
            {
                var SAUOMIPref = File.ReadAllText(EXELoc + "/Preferences/SAUOMI.AMMIPref");

                if (SAUOMIPref == "true")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            else
            {
                File.WriteAllText(EXELoc + "/Preferences/SAUOMI.AMMIPref", "false");
            }

            if (File.Exists(EXELoc + "/Preferences/CloseAfterInstall.AMMIPref"))
            {
                var CAIPref = File.ReadAllText(EXELoc + "/Preferences/CloseAfterInstall.AMMIPref");

                if (CAIPref == "true")
                {
                    CloseAfterInstall.Checked = true;
                }
                else
                {
                    CloseAfterInstall.Checked = false;
                }
            }
            else
            {
                File.WriteAllText(EXELoc + "/Preferences/CloseAfterInstall.AMMIPref", "false");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var EXELoc = Directory.GetCurrentDirectory();

            var directory = textBox1.Text.ToString();

            File.WriteAllText(EXELoc + "/AM_DLoc.Location", directory);

            if (Directory.Exists(directory))
            {
                label2.Text = "Location found!\n";
                if (textBox2.Text == "")
                {
                    label2.Text = "Location found!\nType in your mod in the other text box and then press install!";
                }
                else
                {
                    var Mod = textBox2.Text.ToString();

                    if (File.Exists(EXELoc + "/Modfolder/" + Mod + ".assets"))
                    {
                        label2.Text = "Location found!\nA mod has already been entered, press install when ready!";
                    }
                    else
                    {
                        label2.Text = "Location found!\nA mod has been typed but does not exist, double check your spelling";
                    }
                }
            }
            else
            {
                label2.Text = "Location was not found.\nDouble check you have pasted it in right.";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var EXELoc = Directory.GetCurrentDirectory();

            var ModChoice = textBox2.Text.ToString();

            var ModFolder = EXELoc + "/ModFolder";

            if (File.Exists(ModFolder + "/" + ModChoice + ".assets"))
            {
                if (ModChoice == "")
                {
                    label5.Text = "";
                }
                else
                {
                    label5.Text = "Mod found. Press install when ready.";
                }
            }
            else
            {
                if (ModChoice == "")
                {
                    label5.Text = "";
                }
                else
                {
                    label5.Text = "Invalid mod. Please type a valid mod.";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var EXELoc = Directory.GetCurrentDirectory();

                if (File.Exists(EXELoc + "/AM_DLoc.Location"))
                {
                    textBox1.Text = File.ReadAllText(EXELoc + "/AM_DLoc.Location");
                }

                var ModChoice = textBox2.Text.ToString();

                var directory = textBox1.Text.ToString();

                var ModFolder = EXELoc + "/ModFolder";
                if (Directory.Exists(ModFolder))
                {
                    if (Directory.Exists(directory))
                    {
                        if (File.Exists(ModFolder + "/" + ModChoice + ".assets"))
                        {
                            if (ModChoice == "")
                            {
                                MessageBox.Show("Mod cannot be installed because a mod was not chosen.", "AMModInstaller", MessageBoxButtons.OK);
                            }
                            else
                            {
                                var file = ModFolder + "/" + ModChoice + ".assets";

                                File.Copy(file, $"{directory + "/"}{ "sharedassets1" }.assets", true);

                                MessageBox.Show("Mod Successfully Installed.", "AMModInstaller", MessageBoxButtons.OK);

                                textBox2.Text = "";

                                label2.Text = "Location found!\nType in your mod in the other text box and then press install!";

                                var AmongUsEXE = Directory.GetParent(directory);

                                var GameEXE = AmongUsEXE.ToString();

                                if (File.Exists(GameEXE + "/Among Us.exe"))
                                {
                                    Process.Start(GameEXE + "/Among Us.exe");
                                }
                                else
                                {
                                    MessageBox.Show("Could not find Among Us.exe in " + GameEXE + ". No process was started.", "AMModInstaller", MessageBoxButtons.OK);
                                }

                                if (CloseAfterInstall.Checked == true)
                                {
                                    var processes = Process.GetProcessesByName("AMModInstaller");

                                    foreach (var process in processes)
                                    {
                                        process.Kill();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mod does not exist. Please try again.", "AMModInstaller", MessageBoxButtons.OK);

                            textBox2.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("The destination location does not exist. Please enter a valid destination location.", "AMModInstaller", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("A ModFolder was not found. No mods were installed.", "AMModInstaller", MessageBoxButtons.OK);

                    textBox2.Text = "";
                }
            }
            else
            {
                var EXELoc = Directory.GetCurrentDirectory();

                if (File.Exists(EXELoc + "/AM_DLoc.Location"))
                {
                    textBox1.Text = File.ReadAllText(EXELoc + "/AM_DLoc.Location");
                }

                var ModChoice = textBox2.Text.ToString();

                var directory = textBox1.Text.ToString();

                var ModFolder = EXELoc + "/ModFolder";

                if (Directory.Exists(ModFolder))
                {
                    if (Directory.Exists(directory))
                    {
                        if (File.Exists(ModFolder + "/" + ModChoice + ".assets"))
                        {
                            if (ModChoice == "")
                            {
                                MessageBox.Show("Mod cannot be installed because a mod was not chosen.", "AMModInstaller", MessageBoxButtons.OK);
                            }
                            else
                            {
                                var file = ModFolder + "/" + ModChoice + ".assets";

                                File.Copy(file, $"{directory + "/"}{ "sharedassets1" }.assets", true);

                                MessageBox.Show("Mod Successfully Installed.", "AMModInstaller", MessageBoxButtons.OK);

                                label2.Text = "Location found!\nType in your mod in the other text box and then press install!";

                                textBox2.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mod does not exist. Please try again.", "AMModInstaller", MessageBoxButtons.OK);

                            textBox2.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("The destination location does not exist. Please enter a valid destination location.", "AMModInstaller", MessageBoxButtons.OK);

                        textBox1.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("A ModFolder was not found. No mods were installed.", "AMModInstaller", MessageBoxButtons.OK);

                    textBox2.Text = "";
                }
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Help Help = new Help();

            Help.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var EXELoc = Directory.GetCurrentDirectory();

            if (checkBox1.Checked == true)
            {
                File.WriteAllText(EXELoc + "/Preferences/SAUOMI.AMMIPref", "true");
            }
            else
            {
                File.WriteAllText(EXELoc + "/Preferences/SAUOMI.AMMIPref", "false");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Social_Links Social_Links = new Social_Links();

            Social_Links.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var Selected = listBox1.SelectedItem.ToString();
            textBox2.Text = Selected;
        }

        private void ToolsButton_Click(object sender, EventArgs e)
        {
            Tools Tools = new Tools();

            Tools.Show();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void RefreshModlist_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var EXELoc = Directory.GetCurrentDirectory();

            var ModFolder = EXELoc + "/ModFolder";

            var ModFolderMods = Directory.GetFiles(ModFolder, "*.*", SearchOption.TopDirectoryOnly);

            foreach (var mod in ModFolderMods)
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(mod));
            }
        }

        private void CloseAfterInstall_CheckedChanged(object sender, EventArgs e)
        {
            var EXELoc = Directory.GetCurrentDirectory();

            if (CloseAfterInstall.Checked == true)
            {
                File.WriteAllText(EXELoc + "/Preferences/CloseAfterInstall.AMMIPref", "true");
            }
            else
            {
                File.WriteAllText(EXELoc + "/Preferences/CloseAfterInstall.AMMIPref", "false");
            }
        }
    }
}
