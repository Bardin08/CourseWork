using CourseWork.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.HasKey(bookModel => bookModel.Id).HasName("book_pkey");
            builder.Property(bookModel => bookModel.Id).HasColumnName("book_id");
            builder.Property(bookModel => bookModel.Author).HasColumnName("book_author_id");
            builder.Property(bookModel => bookModel.Name).HasColumnName("book_name");
            builder.Property(bookModel => bookModel.Description).HasColumnName("book_description").HasMaxLength(1024);
            builder.Property(bookModel => bookModel.PublishYear).HasColumnName("book_publish_year");
            builder.Property(bookModel => bookModel.ISBN).HasColumnName("book_publish_year").HasMaxLength(17);
            builder.Property(bookModel => bookModel.KeyWords).HasColumnName("book_key_words");
        }
    }
}