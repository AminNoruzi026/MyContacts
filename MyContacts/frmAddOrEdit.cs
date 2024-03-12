using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class frmAddOrEdit : Form
    {
        //IContactsRepository repository;
        Contact_DBEntities db = new Contact_DBEntities();
        public int contactId = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
            //repository = new ContactsRepository();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                //bool isSuccess;
                if (contactId == 0)
                {
                    //isSuccess = repository.Insert(txtName.Text, txtFamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text, txtAddress.Text);
                    MyContact contact = new MyContact();
                    contact.Name = txtName.Text;
                    contact.Family = txtFamily.Text;
                    contact.Age = (int)txtAge.Value;
                    contact.Mobile = txtMobile.Text;
                    contact.Address = txtAddress.Text;
                    contact.Email = txtEmail.Text;
                    db.MyContacts.Add(contact);
                }
                else
                {
                    //isSuccess= repository.Update(contactId,txtName.Text, txtFamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text, txtAddress.Text);

                    //contact.ContactID = contactId;
                    //db.Entry(contact).State = EntityState.Modified;

                    var contact = db.MyContacts.Find(contactId);
                    contact.Name = txtName.Text;
                    contact.Family = txtFamily.Text;
                    contact.Age = (int)txtAge.Value;
                    contact.Email = txtEmail.Text;
                    contact.Mobile = txtMobile.Text;
                    contact.Address = txtAddress.Text;
                }

                db.SaveChanges();

                //if (isSuccess == true)
                //{
                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                //}
                //else
                //{
                //    MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                //DataTable dt = repository.SelectRow(contactId);
                MyContact contact = db.MyContacts.Find(contactId);
                txtName.Text = contact.Name;
                txtFamily.Text = contact.Family;
                txtMobile.Text = contact.Mobile;
                txtEmail.Text = contact.Email;
                txtAge.Text = contact.Age.ToString();
                txtAddress.Text = /*dt.Rows[0][6].ToString();*/ contact.Address;
                btnSubmit.Text = "ویرایش";
            }
        }

        bool ValidateInputs()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام خودراوارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی خودراوارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن خودراوارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا موبایل خودراوارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("لطفا ایمیل خودراوارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }
    }
}

