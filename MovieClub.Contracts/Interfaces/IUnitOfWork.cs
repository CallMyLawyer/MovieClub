namespace MovieClub.Contracts.Interfaces;

public interface IUnitOfWork
{
   Task Begin();
   Task Complete();
   Task Commit();
   Task Rollback();
}