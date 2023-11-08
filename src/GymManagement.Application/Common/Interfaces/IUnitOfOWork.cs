namespace GymManagement.Application;

/// <summary>
/// Unit of work interface
/// </summary>
public interface IUnitOfOWork
{
  Task CommitChangedAsync();
}
