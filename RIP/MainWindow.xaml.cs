using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace RIP
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private RIPModel db;
		public MainWindow()
		{
			InitializeComponent();

			db = new RIPModel();

			UpdateTables();
		}

		private void Update_Click(object sender, RoutedEventArgs e)
		{
			db.SaveChanges();
			UpdateTables();
		}

		private void Remove_Click(object sender, RoutedEventArgs e)
		{
			if (CompanyGrid.SelectedItems.Count > 0)
			{
				for (int i = 0; i < CompanyGrid.SelectedItems.Count; i++)
				{
					TB_COMPANY temp = (TB_COMPANY)CompanyGrid.SelectedItems[i];
					db.TB_COMPANY.Remove(temp);
				}
			}
			else if (UsersGrid.SelectedItems.Count > 0)
			{
				for (int i = 0; i < UsersGrid.SelectedItems.Count; i++)
				{
					TB_USERS temp = (TB_USERS)UsersGrid.SelectedItems[i];
					db.TB_USERS.Remove(temp);
				}
			}
			db.SaveChanges();
			UpdateTables();
		}

		private void UpdateTables()
		{
			db.TB_COMPANY.Load();
			db.TB_USERS.Load();

			CompanyGrid.ItemsSource = db.TB_COMPANY.Local.ToBindingList();
			UsersGrid.ItemsSource = db.TB_USERS.Local.ToBindingList();
		}

		private void CompanyGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			TB_COMPANY temp = CompanyGrid.CurrentItem as TB_COMPANY;

			if (!temp.Equals(null))
			{
				var tb_users = from item in db.TB_USERS
							   where item.CL_IdCOMPANY == temp.CL_ID
							   select item;
				if (!tb_users.Equals(null))
				{
					UsersGrid.ItemsSource = tb_users.ToList();
				}
			}
		}
	}
}
