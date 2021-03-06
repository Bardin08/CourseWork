﻿using CourseWork.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.Data.Configurations
{
    internal class KeyWordsConfiguration : IEntityTypeConfiguration<KeyWordModel>
    {
        public void Configure(EntityTypeBuilder<KeyWordModel> builder)
        {
            builder.HasKey(keyWordsModel => keyWordsModel.Id).HasName("key_word_pkey");
            builder.Property(keyWordsModel => keyWordsModel.Id).HasColumnName("key_word_id");
            builder.Property(keyWordsModel => keyWordsModel.Word).HasColumnName("key_word").HasMaxLength(64);
        }
    }
}