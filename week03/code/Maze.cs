/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private Dictionary<(int x, int y), (bool Left, bool Right, bool Up, bool Down)> _maze;
    private (int x, int y) _currentLocation;

    public void MoveLeft()
    {
        if (_maze[_currentLocation].Left)
        {
            _currentLocation = (_currentLocation.x - 1, _currentLocation.y);
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveRight()
    {
        if (_maze[_currentLocation].Right)
        {
            _currentLocation = (_currentLocation.x + 1, _currentLocation.y);
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveUp()
    {
        if (_maze[_currentLocation].Up)
        {
            _currentLocation = (_currentLocation.x, _currentLocation.y + 1);
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveDown()
    {
        if (_maze[_currentLocation].Down)
        {
            _currentLocation = (_currentLocation.x, _currentLocation.y - 1);
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }
}
