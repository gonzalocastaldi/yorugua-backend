namespace Domain.CustomExceptions;

public class UsernameAlreadyExistsException(string message) : Exception(message)
{
    
}