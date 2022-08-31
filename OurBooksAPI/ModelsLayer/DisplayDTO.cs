using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class DisplayDTO
    {
        /// <summary>
        /// Data transfer object for displaying products
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="bookName"></param>
        /// <param name="genre"></param>
        /// <param name="numberPages"></param>
        /// <param name="author"></param>
        /// <param name="inStock"></param>
        /// <param name="cost"></param>
        public DisplayDTO(string? isbn, string? bookName, int? numberPages, string? genre, string? author, int? inStock, decimal? cost)
        {
            ISBN = isbn;
            BookName = bookName;
            NumberPages = numberPages;
            Genre = genre;
            Author = author;
            InStock = inStock;
            Cost = cost;
        }

        // Properties for constructors
        public string? ISBN { get; set; }
        public string? BookName { get; set; }
        public string? Genre { get; set; }
        public int? NumberPages { get; set; }
        public string? Author{ get; set; }
        public int? InStock { get; set; }
        public decimal? Cost { get; set; } 
    }
}
