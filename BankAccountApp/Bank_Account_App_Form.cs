using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankAccountApp;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BankAccountApp
{
    public partial class Bank_Account_App_Form : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        NoServiceChargeChecking n;
        ServiceChargeChecking sc;
        SavingsAccount s;
        InvestmentAccount i;

        public Bank_Account_App_Form()
        {
            InitializeComponent();

            player.SoundLocation = "videoplayback.wav";
        }

        private void Bank_Account_App_Form_Load(object sender, EventArgs e)
        {

        }

        private void no_service_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            title.Text = "No Service Charge Account";
            min_balance_label.Visible = true;
            min_balance_textBox.Visible = true;

            commission_label.Visible = false;
            default_commision_label.Visible = false;
            interest_rate_label.Visible = false;
            interest_rate_textBox.Visible = false;
            channel_label.Visible = false;
            channel_comboBox.Visible = false;

        }

        private void service_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            title.Text = "Service Charge Account";
            commission_label.Visible = true;
            default_commision_label.Visible = true;

            min_balance_label.Visible = false;
            min_balance_textBox.Visible = false;
            interest_rate_label.Visible = false;
            interest_rate_textBox.Visible = false;
            channel_label.Visible = false;
            channel_comboBox.Visible = false;
        }

        private void savings_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            title.Text = "Savings Account";
            interest_rate_label.Visible = true;
            interest_rate_textBox.Visible = true;

            min_balance_label.Visible = false;
            min_balance_textBox.Visible = false;
            commission_label.Visible = false;
            default_commision_label.Visible = false;
            channel_label.Visible = false;
            channel_comboBox.Visible = false;
        }

        private void investment_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            title.Text = "Investment Account";
            channel_label.Visible = true;
            channel_comboBox.Visible = true;

            interest_rate_label.Visible = false;
            interest_rate_textBox.Visible = false;
            min_balance_label.Visible = false;
            min_balance_textBox.Visible = false;
            commission_label.Visible = false;
            default_commision_label.Visible = false;
        }

        private void create_account_btn_Click_1(object sender, EventArgs e)
        {            
            if (account_number_textBox.Text == "" || owner_name_textBox.Text == "" || owner_id_textBox.Text == "" || amount_textBox.Text == "" || (male_radioButton.Checked == false && female_radioButton.Checked == false))
            {
                MessageBox.Show("You must fill all the details!");
                return;
            }

            if(no_service_radioButton.Checked == false && service_radioButton.Checked == false && savings_radioButton.Checked == false && investment_radioButton.Checked == false)
            {
                MessageBox.Show("You must choose a type!");
                return;
            }

            if (CheckAllNodes(treeView.Nodes, account_number_textBox.Text) == false)
            {
                MessageBox.Show("There is already exist an account with this number!");
                return;
            }

            if (title.Text == "No Service Charge Account")
            {
                deposit_label.Visible = true;
                cash_button.Visible = true;
                check_button.Visible = true;
                deposit_btn.Visible = true;
                deposit_textBox.Visible = true;
                calculate_balance_button.Visible = true;
                withdraw_label.Visible = true;
                withdraw_btn.Visible = true;
                n = new NoServiceChargeChecking(int.Parse(account_number_textBox.Text), owner_name_textBox.Text, owner_id_textBox.Text, double.Parse(amount_textBox.Text), double.Parse(min_balance_textBox.Text));
                details_title_label.Visible = true;
                details_label.Text = n.toString(n.getAccountNum(), n.getOwnerName(), n.getOwnerID(), n.getAccountBalance(), n.getMinBalance());
                details_label.Visible = true;
                TreeNode root = new TreeNode("Account number: " + n.getAccountNum());
                treeView.Nodes.Add(root);
                root.Nodes.Add("Owner name: " + n.getOwnerName());
                root.Nodes.Add("Owner ID: " + n.getOwnerID());
                root.Nodes.Add("Type account: " + title.Text);
                accounts_delete_comboBox.Items.Add("Account number: " + n.getAccountNum());

                player.Play();
            }

            if (title.Text == "Service Charge Account")
            {
                deposit_label.Visible = true;
                cash_button.Visible = true;
                check_button.Visible = true;
                deposit_btn.Visible = true;
                deposit_textBox.Visible = true;
                calculate_balance_button.Visible = true;
                withdraw_label.Visible = true;
                withdraw_btn.Visible = true;
                sc = new ServiceChargeChecking(int.Parse(account_number_textBox.Text), owner_name_textBox.Text, owner_id_textBox.Text, double.Parse(amount_textBox.Text), 6.9);
                details_title_label.Visible = true;
                details_label.Text = sc.toString(sc.getAccountNum(), sc.getOwnerName(), sc.getOwnerID(), sc.getAccountBalance(), 6.9);
                details_label.Visible = true;
                TreeNode root = new TreeNode("Account number: " + sc.getAccountNum());
                treeView.Nodes.Add(root);
                root.Nodes.Add("Owner name: " + sc.getOwnerName());
                root.Nodes.Add("Owner ID: " + sc.getOwnerID());
                root.Nodes.Add("Type account: " + title.Text);
                accounts_delete_comboBox.Items.Add("Account number: " + sc.getAccountNum());

                player.Play();
            }

            if (title.Text == "Savings Account")
            {
                deposit_label.Visible = true;
                deposit_textBox.Visible = true;
                deposit_btn.Visible = true;
                calculate_balance_button.Visible = true;
                withdraw_label.Visible = true;
                withdraw_textBox.Visible = true;
                withdraw_btn.Visible = true;
                s = new SavingsAccount(int.Parse(account_number_textBox.Text), owner_name_textBox.Text, owner_id_textBox.Text, double.Parse(amount_textBox.Text), double.Parse(interest_rate_textBox.Text));
                details_title_label.Visible = true;
                details_label.Text = s.toString(s.getAccountNum(), s.getOwnerName(), s.getOwnerID(), s.getAccountBalance(), s.getInterestRate());
                details_label.Visible = true;
                TreeNode root = new TreeNode("Account number: " + s.getAccountNum());
                treeView.Nodes.Add(root);
                root.Nodes.Add("Owner name: " + s.getOwnerName());
                root.Nodes.Add("Owner ID: " + s.getOwnerID());
                root.Nodes.Add("Type account: " + title.Text);
                accounts_delete_comboBox.Items.Add("Account number: " + s.getAccountNum());

                player.Play();
            }

            if (title.Text == "Investment Account")
            {
                if (channel_comboBox.Text == "")
                {
                    MessageBox.Show("You nust choose a channel!");
                    return;
                }

                deposit_label.Visible = true;
                deposit_textBox.Visible = true;
                deposit_btn.Visible = true;
                calculate_balance_button.Visible = true;
                invest_label.Visible = true;
                invest_textBox.Visible = true;
                invest_button.Visible = true;
                withdraw_label.Visible = true;
                withdraw_textBox.Visible = true;
                withdraw_btn.Visible = true;
                i = new InvestmentAccount(int.Parse(account_number_textBox.Text), owner_name_textBox.Text, owner_id_textBox.Text, double.Parse(amount_textBox.Text), double.Parse(interest_rate_textBox.Text), channel_comboBox.Text);
                details_title_label.Visible = true;
                details_label.Text = i.toString(i.getAccountNum(), i.getOwnerName(), i.getOwnerID(), i.getAccountBalance(), i.getInvesment(i.getInvestmentChannel()), i.getInvestmentChannel());
                details_label.Visible = true;
                TreeNode root = new TreeNode("Account number: " + i.getAccountNum());
                treeView.Nodes.Add(root);
                root.Nodes.Add("Owner name: " + i.getOwnerName());
                root.Nodes.Add("Owner ID: " + i.getOwnerID());
                root.Nodes.Add("Type account: " + title.Text);
                accounts_delete_comboBox.Items.Add("Account number: " + i.getAccountNum());

                player.Play();
            }
        }

        private void deposit_btn_Click_1(object sender, EventArgs e)
        {
            if (title.Text == "No Service Charge Account")
            {
                n.deposit(double.Parse(deposit_textBox.Text));
                details_label.Text = n.toString(n.getAccountNum(), n.getOwnerName(), n.getOwnerID(), n.getAccountBalance(), n.getMinBalance());
                deposit_textBox.Text = "";
                MessageBox.Show("Successfully deposited! \nYour current balance is: " + n.getAccountBalance());
            }

            if (title.Text == "Service Charge Account")
            {
                sc.deposit(double.Parse(deposit_textBox.Text));
                details_label.Text = sc.toString(sc.getAccountNum(), sc.getOwnerName(), sc.getOwnerID(), sc.getAccountBalance(), 6.9);
                deposit_textBox.Text = "";
                MessageBox.Show("Successfully deposited! \nYour current balance is: " + sc.getAccountBalance());
            }

            if (title.Text == "Savings Account")
            {
                s.deposit(double.Parse(deposit_textBox.Text));
                details_label.Text = s.toString(s.getAccountNum(), s.getOwnerName(), s.getOwnerID(), s.getAccountBalance(), s.getInterestRate());
                deposit_textBox.Text = "";
                MessageBox.Show("Successfully deposited! \nYour current balance is: " + s.getAccountBalance());
            }

            if (title.Text == "Investment Account")
            {
                i.deposit(double.Parse(deposit_textBox.Text));
                details_label.Text = i.toString(i.getAccountNum(), i.getOwnerName(), i.getOwnerID(), i.getAccountBalance(), i.getInvesment(i.getInvestmentChannel()), i.getInvestmentChannel());
                deposit_textBox.Text = "";
                MessageBox.Show("Successfully deposited! \nYour current balance is: " + i.getAccountBalance());
            }
        }

        private void withdraw_btn_Click_1(object sender, EventArgs e)
        {
            deposit_textBox.Visible = true;
            if (title.Text == "No Service Charge Account")
            {
                if (n.withdrawWithMinBalanceLimit(double.Parse(withdraw_textBox.Text)) == false)
                    MessageBox.Show("You can withdraw up to " + (n.getAccountBalance() - n.getMinBalance()));
                else
                {
                    details_label.Text = n.toString(n.getAccountNum(), n.getOwnerName(), n.getOwnerID(), n.getAccountBalance(), n.getMinBalance());
                    check_pictureBox.Visible = false;
                    withdraw_textBox.Visible = false;
                    ownerName_check_textBox.Visible = false;
                    withdraw_textBox.Text = "";
                    cash_button.Visible = true;
                    check_button.Visible = true;
                    MessageBox.Show("Successfully withdrawed! \nYour current balance is: " + n.getAccountBalance());
                }
            }

            if (title.Text == "Service Charge Account")
            {
                if (sc.withdrawWithCommission(double.Parse(withdraw_textBox.Text)) == false)
                    MessageBox.Show("You can withdraw up to " + (sc.getAccountBalance() - 6.9));
                else
                {
                    details_label.Text = sc.toString(sc.getAccountNum(), sc.getOwnerName(), sc.getOwnerID(), sc.getAccountBalance(), 6.9);
                    check_pictureBox.Visible = false;
                    withdraw_textBox.Visible = false;
                    ownerName_check_textBox.Visible = false;
                    withdraw_textBox.Text = "";
                    cash_button.Visible = true;
                    check_button.Visible = true;
                    MessageBox.Show("Successfully withdrawed! \nYour current balance is: " + sc.getAccountBalance());
                }
            }

            if (title.Text == "Savings Account")
            {
                if (double.Parse(withdraw_textBox.Text) > s.getAccountBalance())
                    MessageBox.Show("You can withdraw up to " + s.manageAccount());
                else
                {
                    s.withdraw(double.Parse(withdraw_textBox.Text));
                    details_label.Text = s.toString(s.getAccountNum(), s.getOwnerName(), s.getOwnerID(), s.getAccountBalance(), s.getInterestRate());
                    withdraw_textBox.Text = "";
                    MessageBox.Show("Successfully withdrawed! \nYour current balance is: " + s.getAccountBalance());
                }
            }

            if (title.Text == "Investment Account")
            {
                if (double.Parse(withdraw_textBox.Text) > i.getAccountBalance())
                    MessageBox.Show("You can withdraw up to " + i.getAccountBalance());
                else
                {
                    i.withdraw(double.Parse(withdraw_textBox.Text));
                    details_label.Text = i.toString(i.getAccountNum(), i.getOwnerName(), i.getOwnerID(), i.getAccountBalance(), i.getInvesment(i.getInvestmentChannel()), i.getInvestmentChannel());
                    withdraw_textBox.Text = "";
                    MessageBox.Show("Successfully withdrawed! \nYour current balance is: " + i.getAccountBalance());
                }
            }
        }

        private void save_details_btn_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "model files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (SaveFile(saveFileDialog1.FileName, treeView.Nodes))
                {
                    var lines = File.ReadAllLines(saveFileDialog1.FileName);
                    string itemCode = "TreeNode: ";
                    var newLine = lines.Select(line => line.Replace(itemCode, string.Empty));
                    File.WriteAllLines(saveFileDialog1.FileName, newLine);

                    MessageBox.Show("Successfully saved!");
                }
            }
        }

        private bool SaveFile(string f, TreeNodeCollection nodes)
        {
            StreamWriter sw = new StreamWriter(f);
            try
            {
                DateTime date = DateTime.Today;
                sw.WriteLine(date.ToString("dd/MM/yyyy"));
                sw.Write("\n");

                foreach (TreeNode node in nodes)
                {
                    sw.WriteLine(node);
                    for (int i = 0; i < node.Nodes.Count; i++)
                    {
                        sw.WriteLine(node.Nodes[i]);
                    }
                    sw.Write("\n");
                }
                return true;
            }
            catch { return false; }
            finally { sw.Close(); }
        }

        private void load_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "model files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReadFile(openFileDialog1.FileName);
                MessageBox.Show("Successfully loaded!");
            }
        }

        private void ReadFile(string f)
        {
            StreamReader sr = new StreamReader(f);
            string line;
            TreeNode root = new TreeNode();
            while ((line = sr.ReadLine()) != null)
            {
                string[] items = line.Split('\n');
                foreach (string item in items)
                {
                    if (item.StartsWith("Account number: "))
                    {
                        root = new TreeNode();
                        root.Text = item;
                        treeView.Nodes.Add(root);
                        accounts_delete_comboBox.Items.Add(root.Text);
                    }
                    if (item.StartsWith("Owner name: ") || item.StartsWith("Owner ID: ") || item.StartsWith("Type account: "))
                    {
                        root.Nodes.Add(item);
                    }
                } 
            }
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            no_service_radioButton.Checked = false;
            service_radioButton.Checked = false;
            savings_radioButton.Checked = false;
            investment_radioButton.Checked = false;
            male_radioButton.Checked = false;
            female_radioButton.Checked = false;
            deposit_label.Visible = false;
            deposit_textBox.Visible = false;
            deposit_btn.Visible = false;
            withdraw_label.Visible = false;
            withdraw_textBox.Visible = false;
            withdraw_btn.Visible = false;
            min_balance_label.Visible = false;
            min_balance_textBox.Visible = false;
            commission_label.Visible = false;
            default_commision_label.Visible = false;
            interest_rate_label.Visible = false;
            interest_rate_textBox.Visible = false;
            channel_label.Visible = false;
            channel_comboBox.Visible = false;
            details_label.Visible = false;
            details_title_label.Visible = false;
            invest_button.Visible = false;
            invest_textBox.Visible = false;
            invest_label.Visible = false;
            ok_delete_button.Visible = false;
            accounts_delete_comboBox.Visible = false;
            cash_button.Visible = false;
            check_button.Visible = false;
            check_pictureBox.Visible = false;
            calculate_balance_button.Visible = false;
            ownerName_check_textBox.Visible = false;
            man_pictureBox.Visible = false;
            woman_pictureBox.Visible = false;
            withdraw_textBox.Size = new System.Drawing.Size(249, 29);
            withdraw_textBox.Location = new Point(266, 375);
            title.Text = "No Service Charge Account";
            account_number_textBox.Text = "";
            owner_name_textBox.Text = "";
            owner_id_textBox.Text = "";
            amount_textBox.Text = "";
            deposit_textBox.Text = "";
            withdraw_textBox.Text = "";
            min_balance_textBox.Text = "0";
            interest_rate_textBox.Text = "0.1";
            invest_textBox.Text = "";
            channel_comboBox.Text = null;
        }

        private void invest_button_Click(object sender, EventArgs e)
        {
            if (i.invest(double.Parse(invest_textBox.Text), channel_comboBox.Text) == false)
            {
                MessageBox.Show("You can invest up to " + i.getAccountBalance());
                invest_textBox.Text = "";
            }
            else
            {
                details_label.Text = i.toString(i.getAccountNum(), i.getOwnerName(), i.getOwnerID(), i.getAccountBalance(), i.getInterestRate(), i.getInvestmentChannel());
                MessageBox.Show("Your current balance is: " + i.getAccountBalance());
                invest_textBox.Text = "";
            }
        }

        private bool CheckAllNodes(TreeNodeCollection nodes, string accountNum)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == "Account number: " + accountNum)
                    return false;
            }
            return true;
        }

        private void delete_account_button_Click(object sender, EventArgs e)
        {
            accounts_delete_comboBox.Visible = true;
            ok_delete_button.Visible = true;
        }

        private void delete_account(TreeNodeCollection nodes, string accountNum)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text.Equals(accountNum))
                {
                    node.Remove();
                    return;
                }
            }
        }
        
        private void ok_delete_button_Click(object sender, EventArgs e)
        {
            delete_account(treeView.Nodes, accounts_delete_comboBox.Text);
            accounts_delete_comboBox.Items.Remove(accounts_delete_comboBox.Text);
            accounts_delete_comboBox.Text = null;
        }

        private void cash_button_Click(object sender, EventArgs e)
        {
            cash_button.Visible = false;
            check_button.Visible = false;
            withdraw_textBox.Size = new System.Drawing.Size(249, 29);
            withdraw_textBox.Location = new Point(266, 375);
            withdraw_textBox.Visible = true;
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            withdraw_textBox.Visible = true;
            withdraw_textBox.Size = new System.Drawing.Size(91, 38);
            withdraw_textBox.Location = new Point(600, 356);
            ownerName_check_textBox.Text = owner_name_textBox.Text;
            ownerName_check_textBox.Visible = true;
            
            check_pictureBox.Visible = true;
            cash_button.Visible = false;
            check_button.Visible = false;
            deposit_textBox.Visible = false;
        }

        private void calculate_balance_button_Click(object sender, EventArgs e)
        {
            if (title.Text == "No Service Charge Account")
            {
                MessageBox.Show("Your calculated balance is: " + n.manageAccount());
            }

            if (title.Text == "Service Charge Account")
            {
                MessageBox.Show("Your calculated balance is: " + sc.manageAccount());
            }

            if (title.Text == "Savings Account")
            {
                MessageBox.Show("Your calculated balance is: " + s.manageAccount());
            }

            if (title.Text == "Investment Account")
            {
                MessageBox.Show("Your calculated balance is: " + i.manageAccount());
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void male_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            man_pictureBox.Visible = true;
            woman_pictureBox.Visible = false;
        }

        private void female_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            man_pictureBox.Visible = false;
            woman_pictureBox.Visible = true;
        }
    }
}
