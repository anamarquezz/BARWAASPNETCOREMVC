using LittlePacktBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Services
{
	public class MockBooksRepository : IRepository<Book>
	{
		List<Book> _books;
		public MockBooksRepository()
		{
			_books = new List<Book>()
			{
				new Book()
				{
					Id =0,
					Title ="JavaScript and JSON Essentials",
					Description="Use JSON for building web applications with technologies like HTML, JavaScript, Angular, Node.js, Hapi.js, Kafka, socket.io, MongoDB, Gulp.js, and handlebar.js, and others formats like GEOJSON, JSON-LD, MessagePack, and BSON.",
					Author="Bruno Joseph D'mello, Sai Srinivas Sriparasa",
					PublishDate="April 2018",
					Price=30,
					image="00.png"
				},
				new Book()
				{
					Id =1,
					Title ="C# and .NET Core Test Driven Development",
					Description="Learn how to apply a test-driven development process by building ready C# 7 and .NET Core applications.",
					Author="Ayobami Adewole",
					PublishDate="May 2018",
					Price=25,
					image="01.png"
				},
				new Book()
				{
					Id =2,
					Title ="ASP.NET Core 2 and Angular 5",
					Description="Develop a simple, yet fully-functional modern web application using ASP.NET Core MVC, Entity Framework and Angular 5.",
					Author="Valerio De Sanctis",
					PublishDate="November 2017",
					Price=20,
					image="02.png"
				},
				new Book()
				{
					Id =3,
					Title ="Dependency Injection in .NET Core 2.0",
					Description="Inject dependencies and write highly maintainable and flexible code using the new .NET Core DI Engine",
					Author="Marino Posadas, Tadit Dash",
					PublishDate="November 2017",
					Price=25,
					image="03.png"
				},
				new Book()
				{
					Id =4,
					Title ="Learning JavaScript Data Structures and Algorithms - Third Edition",
					Description="Create classic data structures and algorithms such as depth-first search and breadth-first search, learn recursion, as well as create and use a heap data structure using JavaScript.",
					Author="Loiane Groner",
					PublishDate="April 2018",
					Price=29.99,
					image="04.png"
				},
				new Book()
				{
					Id =5,
					Title ="Learn Docker - Fundamentals of Docker 18.x",
					Description="Enhance your software deployment workflow using containers",
					Author="Gabriel N. Schenker",
					PublishDate="April 2018",
					Price=30,
					image="05.png"
				},
				new Book()
				{
					Id =6,
					Title ="Mastering Reactive JavaScript",
					Description="Expand your boundaries by creating applications empowered with real-time data using RxJs without compromising performance.",
					Author="Erich de Souza Oliveira",
					PublishDate="May 2017",
					Price=20,
					image="06.png"
				},
				new Book()
				{
					Id =7,
					Title ="JavaScript by Example",
					Description="A project based guide to help you get started with web development by building real-world and modern web applications.",
					Author="Dani Akash S",
					PublishDate="August 2017",
					Price=35,
					image="07.png"
				},
				new Book()
				{
					Id =8,
					Title ="Web Developer's Reference Guide",
					Description="A one-stop guide to the essentials of web development including popular frameworks such as jQuery, Bootstrap, AngularJS, and Node.js.",
					Author="Joshua Johanan, Talha Khan, Ricardo Zea",
					PublishDate="March 2016",
					Price=34.99,
					image="08.jpg"
				},
				new Book()
				{
					Id =9,
					Title ="Node.js Essentials",
					Description="From client to server, learn how Node.js can help you use JavaScript more effectively to develop faster and more scalable applications with ease.",
					Author="Fabian Cook",
					PublishDate="November 2015",
					Price=30,
					image="09.jpg"
				},
				new Book()
				{
					Id =10,
					Title ="Building RESTful Web services with .NET Core",
					Description="Building Complete E-commerce/Shopping Cart Application.",
					Author="Gaurav Aroraa, Tadit Dash",
					PublishDate="May 2018",
					Price=31.99,
					image="10.png"
				},
				new Book()
				{
					Id =11,
					Title ="C# 7 and .NET Core 2.0 High Performance",
					Description="Improve the speed of your code and optimize the performance of your apps",
					Author="Ovais Mehboob Ahmed Khan",
					PublishDate="April 2018",
					Price=25,
					image="11.png"
				},
				new Book()
				{
					Id =12,
					Title =".NET Core 2.0 By Example",
					Description="Build cross-platform solutions with .NET Core 2.0 through real-life scenarios.",
					Author="Rishabh Verma, Neha Shrivastava",
					PublishDate="March 2018",
					Price=30,
					image="12.png"
				},
				new Book()
				{
					Id =13,
					Title ="Beginning C# 7 Hands-On – The Core Language",
					Description="A C# 7 beginners guide to the core parts of the C# language!",
					Author="Tom Owsiak",
					PublishDate="August 2017",
					Price=39.99,
					image="13.png"
				},
			};

		}
		public bool Add(Book item)
		{
			try
			{
				Book book = item;
				book.Id = _books.Max(x => x.Id) + 1;
				_books.Add(book);
				return true;
			}
			catch (Exception)
			{
				//Log it here
				return false;
			}
		}

		public bool Delete(Book Item)
		{
			throw new NotImplementedException();
		}

		public bool Edit(Book item)
		{
			throw new NotImplementedException();
		}

		public Book Get(int id)
		{
			return _books.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Book> GetAll()
		{
			return _books.ToList();
		}
	}
}
