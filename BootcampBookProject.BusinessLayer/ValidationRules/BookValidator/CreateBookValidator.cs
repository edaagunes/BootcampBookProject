using BootcampBookProject.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.BusinessLayer.ValidationRules.BookValidator
{
	public class CreateBookValidator:AbstractValidator<Book>
	{
		public CreateBookValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Kitap Adını Giriniz");
			RuleFor(x => x.Author).NotEmpty().WithMessage("Yazar Adını Giriniz");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Kitap Açıklamasını Giriniz");
			RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Giriniz");
			RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Kitap Görseli Yüklenmelidir");
			RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karakter girmelisiniz");
			RuleFor(x => x.Name).MaximumLength(100).WithMessage("En fazla 100 karakter girebilirsiniz");
			RuleFor(x => x.Author).MinimumLength(5).WithMessage("En az 5 karakter girmelisiniz");
			RuleFor(x => x.Author).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
			RuleFor(x => x.Description).MaximumLength(500).WithMessage("En fazla 500 karakter girebilirsiniz");
		}
	}
}
