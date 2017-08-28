using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yodo1OnlineConfigCaller
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            TextBoxForAddConfig_TextChanged(null, null);
            ifRandomConfig_CheckedChanged(null, null);
        }

        private async void BtnForStartAdd_Click(object sender, EventArgs e)
        {
            int times = 0;
            Int32.TryParse(TextBoxForPrefixOfTimes.Text, out times);
            ServiceCaller.Domains domain = RadioBtnFor132.Checked ? ServiceCaller.Domains.DEV : ServiceCaller.Domains.LOCALHOST;
            await ServiceCaller.MakeMultiAddConfig(domain,TextBoxForGameAppKey.Text, TextBoxForPrefixOfKey.Text, TextBoxForPrefixOfDes.Text, times,(String result)=> {
                LogOut.AppendText(result + System.Environment.NewLine);
            });
        }

        private void TextBoxForAddConfig_TextChanged(object sender, EventArgs e)
        {
            this.BtnForStartAdd.Enabled = !(String.IsNullOrWhiteSpace(this.TextBoxForGameAppKey.Text) ||
                                                                  String.IsNullOrWhiteSpace(this.TextBoxForPrefixOfDes.Text) ||
                                                                  String.IsNullOrWhiteSpace(this.TextBoxForPrefixOfKey.Text) ||
                                                                  String.IsNullOrWhiteSpace(this.TextBoxForPrefixOfTimes.Text));
        }

        private async void BtnForStartModify_Click(object sender, EventArgs e)
        {
            int countOfKey = 0;
            int timesOfPerKey = 0;
            Int32.TryParse(TextBoxForModifyKeyCount.Text, out countOfKey);
            Int32.TryParse(TextBoxForModifyPerKeyCount.Text, out timesOfPerKey);
            ServiceCaller.Domains domain = RadioBtnFor132.Checked ? ServiceCaller.Domains.DEV : ServiceCaller.Domains.LOCALHOST;
            await ServiceCaller.MakeMultiModifyConfig(domain,TextBoxForGameAppKey.Text, countOfKey, timesOfPerKey, (String result) => {
                LogOut.AppendText(result + System.Environment.NewLine);
            });
        }

        private void ifRandomConfig_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxForDataKey.Enabled = !ifRandomConfig.Checked;
            TextBoxForModifyKeyCount.Enabled = ifRandomConfig.Checked;
        }

        private void TextBoxForModifyPerKeyCount_TextChanged(object sender, EventArgs e)
        {
            this.BtnForStartModify.Enabled = !(String.IsNullOrWhiteSpace(this.TextBoxForModifyPerKeyCount.Text));
        }

        private async void BtnForGetData_Click(object sender, EventArgs e)
        {
            ServiceCaller.Domains domain = RadioBtnFor132.Checked ? ServiceCaller.Domains.DEV : ServiceCaller.Domains.LOCALHOST;
            await ServiceCaller.MakeMultiGetConfig(domain,TextBoxForGameAppKey.Text, TextBoxForChannel.Text, TextBoxForVersion.Text, (String result) => {
                LogOut.AppendText(result + System.Environment.NewLine);
            });
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
