/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    internal int Length;
    private Queue<Person> _queue = new Queue<Person>();

    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        Person person = _queue.Dequeue();

        // Infinite turns (0 or less)
        if (person.Turns <= 0)
        {
            _queue.Enqueue(person);
        }
        // Finite turns
        else if (person.Turns > 1)
        {
            person.Turns--;
            _queue.Enqueue(person);
        }
        // If Turns == 1 → do not re-add

        return person;
    }
}