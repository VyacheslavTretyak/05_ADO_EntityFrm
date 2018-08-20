using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchingByAuthor
{
	public partial class SearchingByAuthor : Form
	{
		public SearchingByAuthor()
		{
			InitializeComponent();
		}

		private void btFind_Click(object sender, EventArgs e)
		{
			using (LibraryEntities db = new LibraryEntities())
			{
				var authors = (from a in db.AuthorSet
							   where a.FullName.Contains(tbFind.Text)
							   select a).ToList();
				List<BookSet> books = new List<BookSet>();
				foreach(AuthorSet author in authors)
				{
					books.AddRange(author.BookSet.ToList());
				}
				var list = (from b in books
							select new { b.Id, b.BookName, b.Pages }).Distinct().ToList();
				dataGridView1.DataSource = list;

			}
		}
	}
}
