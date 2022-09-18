

export interface Product{
    isbn: string;
    name: string;
    author: string;
    inStock: number;
    genre: string;
    description: string;
    price: number; 
}

export const products = [
    {
        isbn: "978-0547928227",
        name: "The Hobbit",
        author: "J.R.R. Tolkien",
        inStock: 5,
        genre: "Fantasy",
        description: "Follows the quest of home-loving Bilbo Baggins, the titular hobbit, to win a share of the treasure guarded by a dragon named Smaug",
        price: 19.99, 
    },
    {
        isbn: "978-0316347006",
        name: "How to Train Your Dragon Box Set",
        author: "Cressida Cowell",
        inStock: 0,
        genre: "Fantasy",
        description: "Follows the adventures of a young Viking named Hiccup Horrendous Haddock III (voiced by Jay Baruchel), son of Stoick the Vast, leader of the Viking island of Berk.",
        price: 39.99, 
    },
    {
        isbn: "978-1783127856",
        name: "The Ultimate Dinosaur Encyclopedia",
        author: "Chris Baker",
        inStock: 9,
        genre: "Non-Fiction",
        description: "Covers prehistoric life from the very first vertebrates to the world's mightiest dinosaurs.",
        price: 14.99, 
    },
    {
        isbn: "978-0914098911",
        name: "Calculus,4th Edition",
        author: "Michael Spivak",
        inStock: 99,
        genre: "Education",
        description: "Factor fearlessly, conquer the quadratic formula, and solve linear equations." ,
        price: 99.99, 
    },
];
    // {
        //     isbn: ,
        //     name: ,
        //     author: ,
        //     inStock: ,
        //     Genre: ,
        //     price: , 
        // }
        
        
        
        // INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0914098911', 'Calcus, 4th Edition', 680, 'Education', 'Michael Spivak', 99, 99.99);
        
        
        
        
    // INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0984782857', 'Cracking the Coding Interview', 687, 'Business', 'Gayle Laakmann McDowell', 17, 33.99);
    // INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0547928227', 'The Hobbit', 300, 'Fantasy', 'J. R. R. Tolkien', 5, 19.99);
    // INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0316347006', 'How to Train Your Dragon Box Set', 3328, 'Fantasy', 'Cressida Cowell', 2, 39.99);
    // INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-1783127856', 'The Ultimate Dinosaur Encyclpedia', 160, 'Non-fiction', 'Chris Baker', 9, 14.99);
    // INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-1571989260', 'The 2023 Frarmers Almanac', 288, 'Reference', 'Old Farmers Almanac', 0, 4.99);
    // INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-1913484101', 'Guinness World Records 2022', 256, 'Reference', 'Guiness World Records', 3, 19.99);
    // INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-3319188712', 'A Guide to Hubble Space Telescope Objects', 262, 'Education', 'James Chen and Adam Chen', 6, 21.99);
    // INSERT INTO [dbo].[Products] (ISBN, BookName, NumberPages, Genre, Author, inStock, Cost) VALUES('978-0345535528', 'Game of Thrones box set', 5216, 'Fantasy', 'George R. R. Martin', 11, 36.99);

    // Products
    // ISBN (ISBN, NVARCHAR(15))
    // BookName (BookName, NVARCHAR(50))

    // Author (Author, NVARCHAR(40))
    // Number in stock (inStock, int(5)
    // Genre (Genre, NVARCHAR(15))
    // Cost (Cost, MONEY)