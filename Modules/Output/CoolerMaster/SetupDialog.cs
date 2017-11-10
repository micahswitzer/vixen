using System;
using System.Windows.Forms;
using Common.Controls.Theme;
using Common.Resources.Properties;
using Common.Controls;

namespace VixenModules.Output.CoolerMaster
{
    public partial class SetupDialog : BaseForm
    {
        public SetupDialog(CoolerMasterData data)
        {
            InitializeComponent();
            ForeColor = ThemeColorTable.ForeColor;
            BackColor = ThemeColorTable.BackgroundColor;
            ThemeUpdateControls.UpdateControls(this);
            DeviceType = data.DeviceType;
        }

        public CoolerMasterData.DeviceIndex DeviceType
        {
            get
            {
                return (CoolerMasterData.DeviceIndex)comboBoxDevice.SelectedIndex;
            }
            set
            {
                comboBoxDevice.SelectedIndex = (int)value;
            }
        }

        private void buttonBackground_MouseHover(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackgroundImage = Resources.ButtonBackgroundImageHover;
        }

        private void buttonBackground_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.BackgroundImage = Resources.ButtonBackgroundImage;

        }

        private void groupBoxes_Paint(object sender, PaintEventArgs e)
        {
            ThemeGroupBoxRenderer.GroupBoxesDrawBorder(sender, e, Font);
        }
    }
}