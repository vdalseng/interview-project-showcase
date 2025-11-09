namespace MinimalAPI.ExceptionHandlers;

public class GameNotFoundException() : Exception("Game was not found");

public class InvalidInputException() : Exception("Invalid input:");
