using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TranQuangHuy_Lab2.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string imageCover;

        public Book()
        {
        }

        public Book(int id, string title, string author, string imageCover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.imageCover = imageCover;
        }
        public int Id
        {
            get{return id;}
        }
        [Required(ErrorMessage ="tiêu đề không được trống")]
        [StringLength(250,ErrorMessage ="tiêu đề không vượt quá 250 kí tự")]
        [Display(Name ="tiêu đề")]
        public string Title { get 
            { return title; } set { title = value; } }
        public string Author
        {
            get
            { return author; }
            set { author = value; }
        }
        public string ImageCover
        {
            get
            { return imageCover; }
            set { imageCover = value; }
        }
    }
}