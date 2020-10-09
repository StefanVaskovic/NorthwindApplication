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
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var categories = GetCategories();
            var suppliers = GetSuppliers();
            PopulateComboBoxes(this.cbCategory, categories);
            PopulateComboBoxes(this.cbSupplier, suppliers);
        }

        private IEnumerable<CategoryDto> GetCategories()
        {
            var catOp = new getCategoriesOperation();
            return OperationManager.Instance.ExecuteOperation(catOp).Data as IEnumerable<CategoryDto>;
        }

        private IEnumerable<SupplierDto> GetSuppliers()
        {
            var supOp = new getSuppliersOperation();
            return OperationManager.Instance.ExecuteOperation(supOp).Data as IEnumerable<SupplierDto>;
        }
        private void PopulateComboBoxes(ComboBox c,IEnumerable<Dto> dto)
        {
            c.ValueMember = "Id";
            c.DisplayMember = "Name";
            c.DataSource = dto;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var name = this.tbName.Text;
            var discountinued = this.chbDiscountinued.Checked;
            var categoryId = this.cbCategory.SelectedValue;
            var supplierId = this.cbSupplier.SelectedValue;

            //var name = this.tbName.Text;
            //var discountinued = this.tbDiscountinued.Text;
            //var categoryId = this.cbCategory.SelectedValue;
            //var supplierId = this.cbSupplier.SelectedValue;

            var addProductDto = new AddProductDto 
            {
                Name = name,
                Discountinued = discountinued,
                CategoryId = (int)categoryId,
                SupplierId = (int)supplierId
            };

            var op = new insertProductOperation(addProductDto);
            var result = OperationManager.Instance.ExecuteOperation(op);

            if (!result.Errors.Any())
            {
                MessageBox.Show("Successfuly added!");
                RefreshGrid();
            }
            else
            {
                MessageBox.Show(result.Errors.First()); 
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
