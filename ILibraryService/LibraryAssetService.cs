using System.Collections.Generic;
using System.Linq;
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryContext _context;

        public LibraryAssetService(LibraryContext context)
        {
            _context = context;
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location);
        }

        public LibraryAsset GetById(int id)
        {
//            return _context.LibraryAssets
//                .Include(asset => asset.Status)
//                .Include(asset => asset.Location)

            return GetAll()
                .FirstOrDefault(asset => asset.Id == id);
        }

        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(book => book.Id == id).DeweyIndex;
            }
            //var isBook = _context.LibraryAssets.OfType<Book>().Any(book => book.Id == id);
            return "";
        }
        public string GetIsbn(int id)
        {
            //            var isBook = _context.LibraryAssets.OfType<Book>().Any(book => book.Id == id);
            //            if (isBook)
            //            {
            //                return _context.Books.FirstOrDefault(book => book.Id == id).ISBN;
            //            }
            //            return "";
            if (_context.Books.Any(a => a.Id == id))
            {
                return _context.Books.FirstOrDefault(book => book.Id == id).ISBN;
            }
            return "";
        }


        public string GetAuthorOrDirector(int id)
        {
//            if (_context.Books.Any(b => b.Id == id))
//            {
//                return _context.Books
//                    .FirstOrDefault(b => b.Id == id).Author;
//            }
//            if (_context.Videos.Any(v => v.Id == id))
//            {
//                return _context.Videos
//                    .FirstOrDefault(v => v.Id == id).Director;
//            }
//            return "";

            var isBook = _context.LibraryAssets.OfType<Book>().Any(asset => asset.Id == id);
            //var isVideo = _context.LibraryAssets.OfType<Video>().Any(asset => asset.Id == id);

            return isBook
                ? _context.Books.FirstOrDefault(book => book.Id == id).Author : 
                  _context.Videos.FirstOrDefault(video => video.Id == id).Director
                  
                ?? "Unknown";
        }


        public string GetType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>().Any(b => b.Id == id);
            return book ? "Book" : "Video";
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(asset => asset.Id == id)
                .Title;
        }

        
        public LibraryBranch GetCurrentLocation(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(asset => asset.Id == id).Location;
        }
    }
}