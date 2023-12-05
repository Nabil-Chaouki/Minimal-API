using System.Security.Cryptography.X509Certificates;

namespace Pizzastore.Db;

public record Pizza {
    public int Id { get; set; }
    public string ? Name { get; set; } 
}

public class PizzaDb{
    private static List<Pizza> _pizzas = new List<Pizza>(){
        new Pizza(){Id = 1, Name = "Pepperoni"},
        new Pizza(){Id = 2, Name = "Hawaiian"},
        new Pizza(){Id = 3, Name = "Meat Lovers"},
        new Pizza(){Id = 4, Name = "Veggie"}
    };
    public  List<Pizza> GetPizzas() 
   {
     return _pizzas;
   } 

   public  Pizza ? GetPizzaById(int id){
    return _pizzas.SingleOrDefault( p => p.Id == id);
   }
    
    public  Pizza  UpdatePizza(Pizza update){
        _pizzas = _pizzas.Select(p => p.Id == update.Id ? update : p).ToList();
        return update;

}

public  Pizza AddPizza(Pizza newPizza){
   _pizzas.Add(newPizza);
    return newPizza;
}
public void removePizza(int id){
    var pizza = _pizzas.FirstOrDefault(p => p.Id == id);
    if(pizza != null){
        _pizzas.Remove(pizza);
    }
}
}