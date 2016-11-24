namespace WebBookCatalog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebBookCatalog.Models;
    using System.IO;
 

    internal sealed class Configuration : DbMigrationsConfiguration<WebBookCatalog.Models.WebBookCatalogContext>
    {
        ImageConverter Convert = new ImageConverter();
        private string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebBookCatalog.Models.WebBookCatalogContext context)
        {
            _filePath = Directory.GetParent(_filePath).FullName;

            context.Books.AddOrUpdate(x => x.Id,
        new Book()
        {
            Id = 1,
            Title = "Harry Potter and the Philosopher's Stone",
            Year = 1998,
            Author = "J. K. Rowling",
            Price = 9.99M,
            Genre = "Fantasy",
            Annotation= "This enhanced edition includes the full original text用lus charming illustrations, animations and interactions that bring key moments in the story to life. You値l also find annotations written by J.K. Rowling to give you interesting insights into the world of Harry Potter. Update to iOS 9 to get the full, enriched experience."
                        +"Harry Potter has never played a sport while flying on a broomstick.Hes never worn a cloak of invisibility, befriended a giant, or helped hatch a dragon. All Harry knows is a miserable life with the Dursleys, his horrible aunt and uncle, and their abominable son, Dudley. Harrys room is a tiny closet at the foot of the stairs, and he hasnt had a birthday party in eleven years.",
            Image=Convert.imageToByteArray(_filePath+@"\Content\seedimages\hp1.jpg")


        },
        new Book()
        {
            Id = 2,
            Title = "Harry Potter and the Chamber of Secrets",
            Year = 1998,
            Author = "J. K. Rowling",
            Price = 12.95M,
            Genre = "Fantasy",
            Annotation = "This enhanced edition includes the full original text用lus charming illustrations, animations and interactions that bring key moments in the story to life. You値l also find annotations written by J.K. Rowling to give you interesting insights into the world of Harry Potter. Update to iOS 9 to get the full, enriched experience."
                        +"Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School of Witchcraft and Wizardry.But just as hes packing his bags, Harry receives a warning from a strange, impish creature who says that if Harry returns to Hogwarts, disaster will strike.",
            Image = Convert.imageToByteArray(_filePath+@"\Content\seedimages\hp2.jpg")

        },
        new Book()
        {
            Id = 3,
            Title = "Harry Potter and the Prisoner of Azkaban",
            Year = 1999,
            Author = "J. K. Rowling",
            Price = 15,
            Genre = "Fantasy",
            Annotation = "This enhanced edition includes the full original text用lus charming illustrations, animations and interactions that bring key moments in the story to life. You値l also find annotations written by J.K. Rowling to give you interesting insights into the world of Harry Potter. Update to iOS 9 to get the full, enriched experience."
                        +"For twelve long years,the dread fortress of Azkaban held an infamous prisoner named Sirius Black.Convicted of killing thirteen people with a single curse, he was said to be the heir apparent to the Dark Lord, Voldemort.",
            Image = Convert.imageToByteArray(_filePath+@"\Content\seedimages\hp3.jpg")

        },
        new Book()
        {
            Id = 4,
            Title = "Harry Potter and the Goblet of Fire",
            Year = 2000,
            Author = "J. K. Rowling",
            Price = 8.95M,
            Genre = "Fantasy",
            Annotation = "Harry Potter is midway through both his training as a wizard and his coming-of-age. Harry wants to get away from the pernicious Dursleys and go to the Quidditch World Cup with Hermione, Ron, and the Weasleys. He wants to dream about Cho Chang, his crush (and maybe do more than dream). He wants to find out about the mysterious event that's supposed to take place at Hogwarts this year, an event involving two other rival schools of magic, and a competition that hasn't happened for hundreds of years.",
            Image = Convert.imageToByteArray(_filePath+@"\Content\seedimages\hp4.jpg")

        },

       
          new Book()
          {
              Id = 4,
              Title = "A Study in Scarlet",
              Year = 1887,
              Author = "Arthur Conan Doyle",
              Price = 8.95M,
              Genre = "Myster",
              Annotation = "The novel opens with Watson giving a first-person narrative about the contemporary events in his life. He explains that he received his Doctor of Medicine degree in 1878 from the University of London but was immediately assigned to wartime duties as Assistant Surgeon and sent to Bombay. He then traveled to Candahar. The campaign was quite unfortunate for him as he was struck by a bullet in the shoulder and had to be dragged back to British lines by his orderly. He then suffered from typhoid fever.",
              Image = Convert.imageToByteArray(_filePath+@"\Content\seedimages\cd1.jpg")

          },
           new Book()
           {
               Id = 4,
               Title = "The Sign of Four",
               Year = 1890,
               Author = "Arthur Conan Doyle",
               Price = 8.95M,
               Genre = "Myster",
               Annotation = "As a dense yellow fog swirls through the streets of London, a deep melancholy has descended on Sherlock Holmes, who sits in a cocaine-induced haze at 221B Baker Street. His mood is only lifted by a visit from a beautiful but distressed young woman - Mary Morstan, whose father vanished ten years before...",
               Image = Convert.imageToByteArray(_filePath+@"\Content\seedimages\cd2.jpg")
           },
            new Book()
            {
                Id = 4,
                Title = "The Adventures of Sherlock Holmes",
                Year = 1892,
                Author = "Arthur Conan Doyle",
                Price = 8.95M,
                Genre = "Mystery",
                Annotation = "The Adventures of Sherlock Holmes is a collection of twelve stories by Arthur Conan Doyle, featuring his famous detective tales. These are the first of the Sherlock Holmes short stories, originally published as single stories in the Strand Magazine from July 1891 to June 1892. The book was published in England on 14 October 1892 by George Newnes Ltd. and in a US Edition on 15 October by Harper. The initial combined print run was 14,500 copies. The book was banned in the Soviet Union in...",
                Image = Convert.imageToByteArray(_filePath+@"\Content\seedimages\cd3.jpg")
            }
        );
        }
    }
}
