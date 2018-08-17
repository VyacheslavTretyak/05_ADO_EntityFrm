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
			Author a0 = new Author() { FullName = "Gorge stafford" };
			Author a1 = new Author() { FullName = "Gene Kim" };
			Author a2 = new Author() { FullName = "Jez Humble" };
			Author a3 = new Author() { FullName = "Nuddy man" };
			AddAuthor(a0);
			AddAuthor(a1);
			AddAuthor(a2);
			AddAuthor(a3);

			AddUser(new User() { Name = "Kostya" });
			AddUser(new User() { Name = "Chack" });
			AddUser(new User() { Name = "Jackie" });

			Book b = new Book() { BookName = "The DevOps Handbook", Pages = 512 };
			b.Author.Add(GetAuthor("Gene Kim"));
			b.Author.Add(GetAuthor("Jez Humble"));
			b.UserId = GetUser("Chack").Id;
			AddBook(b);
			b = new Book() { BookName = "The Phoenix Project", Pages = 256 };
			b.Author.Add(GetAuthor("Gorge stafford"));
			b.Author.Add(GetAuthor("Gene Kim"));
			b.UserId = GetUser("Jackie").Id;
			AddBook(b);
			b = new Book() { BookName = "Lean Enterprise", Pages = 128 };
			b.Author.Add(GetAuthor("Jez Humble"));
			b.UserId = GetUser("Chack").Id;
			AddBook(b);
			b = new Book() { BookName = "Very not interesting book", Pages = 128 };
			b.Author.Add(GetAuthor("Nuddy man"));			
			AddBook(b);



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
