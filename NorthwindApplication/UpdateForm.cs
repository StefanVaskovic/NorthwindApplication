using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthwindApplication.BusinessLayer;

namespace NorthwindApplication
{
    public partial class UpdateForm : Form
    {
        private ProductsDto _dto;
        public UpdateForm()
        {
            InitializeComponent();
        }

        public UpdateForm(ProductsDto dto)
        {
            _dto = dto;

            InitializeComponent();

            this.tbProductName.Text = _dto.Name;

            var op = new getSuppliersOperation();
            var supDto = OperationManager.Instance.ExecuteOperation(op).Data as IEnumerable<SupplierDto>;

            PopulateComboBoxes(this.cbSupplier, supDto);
            this.cbSupplier.SelectedValue = _dto.SupplierId;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = _dto.Id;
            var name = this.tbProductName.Text;
            var supplierId = (int)this.cbSupplier.SelectedValue;

            var productDto = new ProductsDto 
            {
                Id = id,
                Name = name,
                SupplierId = supplierId
            };

            var op = new updateProductOperation(productDto);
            var result = OperationManager.Instance.ExecuteOperation(op);
            if (result.IsSuccessful)
            {
                MessageBox.Show("Successfuly updated!");
            }
            else
            {
                MessageBox.Show(result.Errors.First());
            }
        }
        private void PopulateComboBoxes(ComboBox c, IEnumerable<Dto> dto)
        {
            c.ValueMember = "Id";
            c.DisplayMember = "Name";
            c.DataSource = dto;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
