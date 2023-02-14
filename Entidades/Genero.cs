using back_end.Validaciones;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades    
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido.")]
        [StringLength(maximumLength:50)]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }



        //Esto sirve agregando : IValidatableObject (esto es por modelo)
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if(!string.IsNullOrEmpty(Nombre))
        //    {
        //        var primeraLetra = Nombre[0].ToString();

        //        if(primeraLetra != primeraLetra.ToUpper())
        //        {
        //            yield return new ValidationResult("La primera letra debe ser mayuscula.",
        //                new string[] {nameof(Nombre) });
        //        }
        //    }
        //}
    }
}
