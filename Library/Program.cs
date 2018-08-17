using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	class Program
	{
		static void Main(string[] args)
		{
			Library lib = new Library();
			lib.Init();

			Console.WriteLine("\n1) Выведите список должников. \n");
			using (EntityModelContainer db = new EntityModelContainer())
			{				
				List<User> users = db.UserSet.ToList().Where(u => u.Book.Count != 0)?.ToList() ?? null;
				foreach(User user in users)
				{
					Console.WriteLine(user.Name);
				}
			}
			Console.WriteLine("\n2) Выведите список авторов книги №3 (по порядку из таблицы ‘Book’). \n");
			using (EntityModelContainer db = new EntityModelContainer())
			{
				Book[] books = db.BookSet.ToArray();
				foreach (Author author in books[2].Author)
				{
					Console.WriteLine(author.FullName);
				}
			}
			Console.WriteLine("\n3) Выведите список книг, которые доступны в данный момент. \n");
			using (EntityModelContainer db = new EntityModelContainer())
			{				
				var books = db.BookSet.ToList().Where(b=>b.UserId == null);
				foreach (Book book in books)
				{
					Console.WriteLine(book.BookName);
				}
			}
			Console.WriteLine("\n4) Вывести список книг, которые на руках у пользователя №2 \n");
			using (EntityModelContainer db = new EntityModelContainer())
			{
				var boo = db.BookSet.ToList();
				var books = db.BookSet.ToList().Where(b => b.User?.Name == "Chack");
				foreach (Book book in books)
				{	
					Console.WriteLine(book.BookName);
				}
			}			
			Console.WriteLine("\n5) Обнулите задолженности всех должников.  \n");
			using (EntityModelContainer db = new EntityModelContainer())
			{
				var books = db.BookSet.ToList().Where(b => b.UserId != null);
				foreach (Book book in books)
				{
					book.UserId = null;
				}
				db.SaveChanges();
			}
			Console.WriteLine("\n1) Выведите список должников. \n");
			using (EntityModelContainer db = new EntityModelContainer())
			{
				List<User> users = db.UserSet.ToList().Where(u => u.Book.Count != 0)?.ToList() ?? null;
				foreach (User user in users)
				{
					Console.WriteLine(user.Name);
				}
			}

		}
	}
}
