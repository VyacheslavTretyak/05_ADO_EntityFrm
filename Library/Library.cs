using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	class Library
	{
		public void Init()
		{
			AddAuthor(new Author() { FullName = "Gorge stafford" });
			AddAuthor(new Author() { FullName = "Gene Kim" });
			AddAuthor(new Author() { FullName = "Jez Humble" });
			AddAuthor(new Author() { FullName = "Nuddy man" });
			AddUser(new User() { Name = "Kostya" });
			AddUser(new User() { Name = "Chack" });
			AddUser(new User() { Name = "Jackie" });
			AddBook(new Book() { BookName = "The DevOps Handbook", Pages = 512 });
			AddBook(new Book() { BookName = "Lean Enterprise", Pages = 256 });
			AddBook(new Book() { BookName = "Very not interesting book", Pages = 2048 });
			using (EntityModelContainer db = new EntityModelContainer()) {
				Book book = db.BookSet.FirstOrDefault(b => b.BookName == "The DevOps Handbook");
				book.Author.Add(db.AuthorSet.FirstOrDefault(a => a.FullName == "Gene Kim"));
				book.Author.Add(db.AuthorSet.FirstOrDefault(a => a.FullName == "Jez Humble"));			
				book.UserId = db.UserSet.FirstOrDefault(u => u.Name == "Chack").Id;

				book = db.BookSet.FirstOrDefault(b => b.BookName == "Lean Enterprise");
				book.Author.Add(db.AuthorSet.FirstOrDefault(a => a.FullName == "Gene Kim"));
				book.Author.Add(db.AuthorSet.FirstOrDefault(a => a.FullName == "Gorge stafford"));
				book.UserId = db.UserSet.FirstOrDefault(u => u.Name == "Chack").Id;

				book = db.BookSet.FirstOrDefault(b => b.BookName == "Very not interesting book");
				book.Author.Add(db.AuthorSet.FirstOrDefault(a => a.FullName == "Nuddy man"));

				db.SaveChanges();

			}

		}
		
		public void PrintAllAuthors()
		{
			using (EntityModelContainer db = new EntityModelContainer())
			{
				foreach (Author author in db.AuthorSet)
				{
					Console.WriteLine(author.FullName);
				}
			}

		}
		public void PrintAllUsers()
		{
			using (EntityModelContainer db = new EntityModelContainer())
			{
				foreach (User user in db.UserSet)
				{
					Console.WriteLine(user.Name);
				}
			}

		}
		public void PrintAllBook()
		{
			using (EntityModelContainer db = new EntityModelContainer())
			{
				foreach (Book book in db.BookSet)
				{
					Console.WriteLine(book.BookName);
				}
			}

		}
		public Author GetAuthor(string authorName)
		{
			Author find = null;
			using (EntityModelContainer db = new EntityModelContainer())
			{
				find = db.AuthorSet.FirstOrDefault(a => a.FullName == authorName);
			}
			Console.WriteLine($"find author : {find.FullName} ");
			return find;
		}
		public User GetUser(string userName)
		{
			User find = null;
			using (EntityModelContainer db = new EntityModelContainer())
			{
				find = db.UserSet.FirstOrDefault(a => a.Name == userName);
			}
			return find;
		}
		public Book GetBook(string bookName)
		{
			Book find = null;
			using (EntityModelContainer db = new EntityModelContainer())
			{
				find = db.BookSet.FirstOrDefault(a => a.BookName == bookName);
			}
			return find;
		}
		public void AddAuthor(Author author)
		{
			using (EntityModelContainer db = new EntityModelContainer())
			{
				Author a = db.AuthorSet.FirstOrDefault(au => au.FullName == author.FullName);
				if (a == null)
				{
					db.AuthorSet.Add(author);
					db.SaveChanges();
					Console.WriteLine($"added author : {author.FullName} ");
				}
				else
				{
					Console.WriteLine($"Author {author.FullName} is exists");
				}
			}
		}
		public void AddBook(Book book)
		{
			using (EntityModelContainer db = new EntityModelContainer())
			{
				Book a = db.BookSet.FirstOrDefault(ent => ent.BookName == book.BookName);
				if (a == null)
				{
					db.BookSet.Add(book);
					db.SaveChanges();
				}
				else
				{
					Console.WriteLine($"Book {book.BookName} is exists");
				}
			}
		}
		public void AddUser(User user)
		{
			using (EntityModelContainer db = new EntityModelContainer())
			{
				User a = db.UserSet.FirstOrDefault(au => au.Name == user.Name);
				if (a == null)
				{
					db.UserSet.Add(user);
					db.SaveChanges();
				}
				else
				{
					Console.WriteLine($"Author {user.Name} is exists");
				}
			}
		}
	}
}
