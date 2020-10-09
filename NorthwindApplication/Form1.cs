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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            this.dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PopulateGridViewCategory();
            //PopulateGridView();
        }

        private IEnumerable<ProductsDto> GetProducts()
        {
            var op = new getProductsOperation();
            var result = OperationManager.Instance.ExecuteOperation(op).Data as IEnumerable<ProductsDto>;


            return result;
        }
        private IEnumerable<CategoryDto> GetCategories()
        {
            var op = new getCategoriesOperation();
            var result = OperationManager.Instance.ExecuteOperation(op).Data as IEnumerable<CategoryDto>;


            return result;
        }
        private void PopulateGridViewProducts()
        {

            var products = GetProducts();
            this.dgvProducts.DataSource = products;
        }
        private void PopulateGridViewCategory()
        {
            var categories = GetCategories();
            this.dgvCategories.DataSource = categories;
        }
        

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var form = new InsertForm();
            form.Show();
            form.Disposed += InsertForm_Disposed;
        }

        private void InsertForm_Disposed(object sender, EventArgs e)
        {
            PopulateGridViewWithSpecificProducts();
        }

        private void PopulateGridViewWithSpecificProducts()
        {
            var selectedCategory = this.dgvCategories.SelectedRows[0].DataBoundItem as CategoryDto;

            var id = selectedCategory.Id;

            var op = new getProductsOperation(id);
            var result = OperationManager.Instance.ExecuteOperation(op);

            if (result.IsSuccessful)
            {
                var data = result.Data as IEnumerable<ProductsDto>;
                this.dgvProducts.DataSource = data;
            }
            else
            {
                MessageBox.Show(result.Errors.First());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvProducts.SelectedRows.Count == 1)
            {
                var selectedProduct = this.dgvProducts.SelectedRows[0].DataBoundItem as ProductsDto;

                var updateForm = new UpdateForm(selectedProduct);
                updateForm.Show();

                updateForm.Disposed += UpdateForm_Disposed;
            }
            else
            {
                MessageBox.Show("You need to select one row");
            }
        }

        private void UpdateForm_Disposed(object sender, EventArgs e)
        {
            PopulateGridViewWithSpecificProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedProducts = this.dgvProducts.SelectedRows;

            var idsToDelete = new List<int>();

            for (int i = 0; i < selectedProducts.Count; i++)
            {
                idsToDelete.Add((selectedProducts[i].DataBoundItem as ProductsDto).Id);
            }

            var opd = new deleteProductOperarion(idsToDelete);
            var result = OperationManager.Instance.ExecuteOperation(opd);
            if (result.IsSuccessful)
            {
                MessageBox.Show("Successfuly deleted!");
                PopulateGridViewWithSpecificProducts();
            }
            else
            {
                MessageBox.Show(result.Errors.First());

            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateGridViewWithSpecificProducts();
        }
    }
}
