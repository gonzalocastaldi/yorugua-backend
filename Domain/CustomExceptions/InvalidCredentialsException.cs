namespace Domain.CustomExceptions;

public class InvalidCredentialsException(string message) : Exception(message)
{ }