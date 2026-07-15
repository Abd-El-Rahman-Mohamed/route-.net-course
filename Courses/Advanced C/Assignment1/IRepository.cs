namespace Assignment1;

// Q6: What is a generic interface? Write IRepository<T>. 
// Q8: What is the 'class' constraint? Write an example.
public interface IRepository<T>
    where T : class
{
    void Add(T item);

    T GetById(int id);

    IEnumerable<T> GetAll();

    void Delete(int id);
}