using System.ComponentModel.DataAnnotations;

namespace lost_woods.Models
{


public class Trail
{
    [Required(ErrorMessage= "Please enter a trail name")]
    [MinLength(3)]
    public string name {get;set;}
        
    [MinLength(5)]
    public string description {get;set;}

   
    public int length {get;set;}

  
    public int elevation {get;set;}

    [Required(ErrorMessage= "Please enter the longitude and latitiude")]
    [Range(0,15000)]

    public int longlat {get;set;}


}



}