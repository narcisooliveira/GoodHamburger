namespace GoodHamburger.Domain.Exceptions;

public class DuplicateItemException(string type) : DomainException($"Item do tipo {type} já adicionado ao pedido")
{
}
