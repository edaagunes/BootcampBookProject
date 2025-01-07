using BootcampBookProject.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampBookProject.BusinessLayer.ValidationRules.CategoryValidator
{
	public class CreateCategoryValidator:AbstractValidator<Category>
	{
		public CreateCategoryValidator()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Giriniz");
			RuleFor(x => x.Status).Must(x => x == true || x == false).WithMessage("Kategori Durumunu True/False Olarak Belirtiniz");
			RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter girmelisiniz");
			RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("En fazla 30 karakter girebilirsiniz");
		}
	}
}
