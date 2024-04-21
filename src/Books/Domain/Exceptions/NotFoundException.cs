namespace Books.Domain.Exceptions;

internal class NotFoundException(string message) : Exception(message)
{
}
