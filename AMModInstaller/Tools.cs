using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AMModInstaller
{
    public partial class Tools : Form
    {
        public Tools()
        {
            InitializeComponent();

            var EXELoc = Directory.GetCurrentDirectory();

            if (File.Exists(EXELoc + "/AM_DLoc.Location"))
            {
                var PrevLoc = File.ReadAllText(EXELoc + "/AM_DLoc.Location");

                PathLabel.Text = PrevLoc;
            }
            else
            {

            }
        }

        private void ModFolderCheckButton_Click(object sender, EventArgs e)
        {
            var EXELoc = Directory.GetCurrentDirectory();

            listBox1.Items.Clear();

            if (Directory.Exists(EXELoc + "/Modfolder"))
            {
                var ModFolder = EXELoc + "/Modfolder";

                var ModFolderMods = Directory.GetFiles(ModFolder, "*.*", SearchOption.TopDirectoryOnly);

                int i = 0;

                foreach (var mod in ModFolderMods)
                {
                    i++;
                }

                if (i == 0)
                {
                    listBox1.Items.Add("NO MODS FOUND");

                    MessageBox.Show("A ModFolder was found. However, no mods were found.", "AMModInstaller Tools", MessageBoxButtons.OK);
                }
                else
                {
                    foreach (var mod in ModFolderMods)
                    {
                        listBox1.Items.Add(Path.GetFileNameWithoutExtension(mod));
                    }

                    MessageBox.Show("A ModFolder was found. All mods are displayed", "AMModInstaller Tools", MessageBoxButtons.OK);
                }
            }
            else
            {
                listBox1.Items.Add("NO MODFOLDER FOUND");

                MessageBox.Show("No ModFolder found.", "AMModInstaller Tools", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var EXELoc = Directory.GetCurrentDirectory();

            if (Directory.Exists(EXELoc + "/Modfolder"))
            {
                Process.Start(EXELoc + "/Modfolder");
            }
            else
            {
                MessageBox.Show("Unable to launch the ModFolder as no ModFolder was found.", "AMModInstaller Tools", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var EXELoc = Directory.GetCurrentDirectory();

            Process.Start(EXELoc);
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            var processes = Process.GetProcessesByName("AMModInstaller");

            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("This does not always find Among Us_Data. Do you wish to continue?", "AMModInstaller Tools", MessageBoxButtons.OKCancel);

            if (dialog == DialogResult.OK)
            {
                var EXELoc = Directory.GetCurrentDirectory();

                if (Directory.Exists(@"C:\Program Files"))
                {

                    if (Directory.Exists("C:" + "/Program Files/Steam/steamapps/common/Among Us/Among Us_Data"))
                    {
                        var AmongUs_DataLoc = "C:" + "/Steam/steamapps/common/Among Us/Among Us_Data";

                        File.WriteAllText(EXELoc + "/AM_DLoc.Location", AmongUs_DataLoc);

                        MessageBox.Show("Found Among Us_Data in " + AmongUs_DataLoc + ".", "AMModInstaller Tools", MessageBoxButtons.OK);

                        PathLabel.Text = AmongUs_DataLoc;
                    }
                    else
                    {
                        if (Directory.Exists("C:" + "/Program Files (x86)/Steam/steamapps/common/Among Us/Among Us_Data"))
                        {
                            var AmongUs_DataLoc = "C:" + "/Steam/steamapps/common/Among Us/Among Us_Data";

                            File.WriteAllText(EXELoc + "/AM_DLoc.Location", AmongUs_DataLoc);

                            MessageBox.Show("Found Among Us_Data in " + AmongUs_DataLoc + ".", "AMModInstaller Tools", MessageBoxButtons.OK);

                            PathLabel.Text = AmongUs_DataLoc;
                        }
                        else
                        {
                            if (Directory.Exists(@"D:\"))
                            {
                                if (Directory.Exists(@"D:\Steam\steamapps\common\Among Us\Among Us_Data"))
                                {
                                    var AmongUs_DataLoc = "D:" + "/Steam/steamapps/common/Among Us/Among Us_Data";

                                    File.WriteAllText(EXELoc + "/AM_DLoc.Location", AmongUs_DataLoc);

                                    MessageBox.Show("Found Among Us_Data in " + AmongUs_DataLoc + ".", "AMModInstaller Tools", MessageBoxButtons.OK);

                                    PathLabel.Text = AmongUs_DataLoc;
                                }
                                else
                                {
                                    MessageBox.Show("Could not automatically find Among Us_Data.", "AMModInstaller Tools", MessageBoxButtons.OK);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Could not automatically find Among Us_Data.", "AMModInstaller Tools", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                else
                {
                    if (Directory.Exists(@"C:\Program Files (x86)"))
                    {
                        if (Directory.Exists("C:" + "/Program Files (x86)/Steam/steamapps/common/Among Us/Among Us_Data"))
                        {
                            var AmongUs_DataLoc = "C:" + "/Steam/steamapps/common/Among Us/Among Us_Data";

                            File.WriteAllText(EXELoc + "/AM_DLoc.Location", AmongUs_DataLoc);

                            MessageBox.Show("Found Among Us_Data in " + AmongUs_DataLoc + ".", "AMModInstaller Tools", MessageBoxButtons.OK);

                            PathLabel.Text = AmongUs_DataLoc;
                        }
                        else
                        {
                            if (Directory.Exists(@"D:\"))
                            {
                                if (Directory.Exists(@"D:\Steam\steamapps\common\Among Us\Among Us_Data"))
                                {
                                    var AmongUs_DataLoc = "D:" + "/Steam/steamapps/common/Among Us/Among Us_Data";

                                    File.WriteAllText(EXELoc + "/AM_DLoc.Location", AmongUs_DataLoc);

                                    MessageBox.Show("Found Among Us_Data in " + AmongUs_DataLoc + ".", "AMModInstaller Tools", MessageBoxButtons.OK);

                                    PathLabel.Text = AmongUs_DataLoc;
                                }
                                else
                                {
                                    MessageBox.Show("Could not automatically find Among Us_Data.", "AMModInstaller Tools", MessageBoxButtons.OK);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Could not automatically find Among Us_Data.", "AMModInstaller Tools", MessageBoxButtons.OK);
                            }
                        }
                    }
                    else
                    {
                        if (Directory.Exists(@"D:\"))
                        {
                            if (Directory.Exists(@"D:\Steam\steamapps\common\Among Us\Among Us_Data"))
                            {
                                var AmongUs_DataLoc = "D:" + "/Steam/steamapps/common/Among Us/Among Us_Data";

                                File.WriteAllText(EXELoc + "/AM_DLoc.Location", AmongUs_DataLoc);

                                MessageBox.Show("Found Among Us_Data in " + AmongUs_DataLoc + ".", "AMModInstaller Tools", MessageBoxButtons.OK);

                                PathLabel.Text = AmongUs_DataLoc;
                            }
                            else
                            {
                                MessageBox.Show("Could not automatically find Among Us_Data.", "AMModInstaller Tools", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Could not automatically find Among Us_Data.", "AMModInstaller Tools", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This compares the default mod in the ModFolder to the sharedassets1 file in Among Us_Data", "AMModInstaller Tools", MessageBoxButtons.OK);

            var EXELoc = Directory.GetCurrentDirectory();

            if (Directory.Exists(EXELoc + "/ModFolder"))
            {
                var ModFolder = EXELoc + "/ModFolder";

                if (File.Exists(ModFolder + "/default.assets"))
                {
                    var DefaultMod = ModFolder + "/default.assets";

                    if (File.Exists(EXELoc + "/AM_DLoc.Location"))
                    {
                        var Location = File.ReadAllText(EXELoc + "/AM_DLoc.Location");

                        if (File.Exists(Location + "/sharedassets1.assets"))
                        {
                            var defaultInfo = new FileInfo(DefaultMod);

                            var sa1Info = new FileInfo(Location + "/sharedassets1.assets");

                            var sa1size = sa1Info.Length;

                            var defaultsize = defaultInfo.Length;

                            if (defaultsize == sa1size)
                            {
                                MessageBox.Show("You have no mods installed.", "AMModInstaller Tools", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("You have a mod installed", "AMModInstaller Tools", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Could not find sharedassets1.assets.", "AMModInstaller Tools", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Could not find an Among Us_Data location.", "AMModInstaller Tools", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Could not find default.assets in the ModFolder", "AMModInstaller Tools", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Could not find a ModFolder.", "AMModInstaller Tools", MessageBoxButtons.OK);
            }

        }

        private void OpenAM_DLoc_Click(object sender, EventArgs e)
        {
            var EXELoc = Directory.GetCurrentDirectory();

            if (File.Exists(EXELoc + "/AM_DLoc.Location"))
            {
                var PrevLoc = File.ReadAllText(EXELoc + "/AM_DLoc.Location");

                if (Directory.Exists(PrevLoc))
                {
                    Process.Start(PrevLoc);
                }
                else
                {
                    MessageBox.Show("A Previous Location Used Does Not Exist. Unable To Open Among Us_Data", "AMModInstaller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("A Location Has Never Been Entered.", "AMModInstaller", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RestartBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }
    }
}
