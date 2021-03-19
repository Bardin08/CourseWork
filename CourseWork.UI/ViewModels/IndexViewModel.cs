﻿using System.Collections.Generic;
using System.Linq;
using CourseWork.LogicLayer.Abstractions;
using CourseWork.Shared.Dtos;
using CourseWork.Shared.Models;

namespace CourseWork.UI.ViewModels
{
    public class IndexViewModel
    {
        private readonly IBookActionProcessor _bookActionProcessor;
        
        public IndexViewModel(IBookActionProcessor bookActionProcessor)
        {
            _bookActionProcessor = bookActionProcessor;
            BookModificationViewModel = new BookModificationPopUpViewModel(bookActionProcessor);
        }

        public List<BookModel> Books { get; set; }
        public BookSearchingDto BookSearchingDto { get; set; }
        public BookModificationPopUpViewModel BookModificationViewModel { get; set; }

        public async void FindBook()
        {
            Books = (await _bookActionProcessor.FindBooks(BookSearchingDto)).ToList();
        }

        public void EditBook(BookModel book)
        {
            BookModificationViewModel.ShowPopUp(book);
        }

        public void DeleteBook(BookModel book)
        {
            Books.RemoveAll(b => b.Id == book.Id);
        
            // TODO: call BookDeleteProvider from LogicLayer (requires method delete by ID)
            // TODO: show confirmation form (maybe admin need to enter the book name to delete it)    
        }
    }

    public class BookModificationPopUpViewModel
    {
        private readonly IBookActionProcessor _bookActionProcessor;
        private List<BookModel> _books;

        public BookModificationPopUpViewModel(IBookActionProcessor bookActionProcessor)
        {
            _bookActionProcessor = bookActionProcessor;
            ShowBookModificationPopUp = false;
        }
        
        public BookModel ModifiableBook { get; private set; }
        public bool ShowBookModificationPopUp { get; set; }

        public void ShowPopUp(BookModel bookToModify)
        {
            if (bookToModify == null) return;
            
            ModifiableBook = bookToModify;
            ShowBookModificationPopUp = true;
        }
        
        public void ClosePopUp()
        {
            ShowBookModificationPopUp = false;
        }
        
        public async void SaveModifiedBook()
        {
            ClosePopUp();

            await _bookActionProcessor.UpdateBookById(ModifiableBook.Id, new BookCreationDto
            {
                Id = ModifiableBook.Id,
                Author = ModifiableBook.Author,
                Description = ModifiableBook.Description,
                Isbn = ModifiableBook.ISBN,
                BookName = ModifiableBook.Name,
                PublishYear = ModifiableBook.PublishYear,
                KeyWordModels = ModifiableBook.KeyWords
            });
        }
    }
}