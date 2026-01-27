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
using System;
using System.Collections.Generic;

public class Maze
{
    private Dictionary<(int, int), (bool Left, bool Right, bool Up, bool Down)> _maze;
    private (int x, int y) _currentLocation;

    // --------------------------------------------------
    // REQUIRED CONSTRUCTOR (tests call this)
    // --------------------------------------------------
    public Maze(int v, (int x, int y) startLocation)
    {
        _currentLocation = startLocation;
        _maze = new Dictionary<(int, int), (bool, bool, bool, bool)>();
        BuildMaze();
    }

    // --------------------------------------------------
    // REQUIRED GetStatus
    // --------------------------------------------------
    public string GetStatus()
    {
        return $"Current location: ({_currentLocation.x},{_currentLocation.y})";
    }

    // --------------------------------------------------
    // MOVEMENT METHODS
    // --------------------------------------------------
    public void MoveLeft()
    {
        if (_maze[_currentLocation].Left)
            _currentLocation = (_currentLocation.x - 1, _currentLocation.y);
    }

    public void MoveRight()
    {
        if (_maze[_currentLocation].Right)
            _currentLocation = (_currentLocation.x + 1, _currentLocation.y);
    }

    public void MoveUp()
    {
        if (_maze[_currentLocation].Up)
            _currentLocation = (_currentLocation.x, _currentLocation.y + 1);
    }

    public void MoveDown()
    {
        if (_maze[_currentLocation].Down)
            _currentLocation = (_currentLocation.x, _currentLocation.y - 1);
    }

    // --------------------------------------------------
    // MAZE DATA (copied from assignment)
    // --------------------------------------------------
    private void BuildMaze()
    {
        _maze[(1,1)] = (false, true,  true,  false);
        _maze[(2,1)] = (true,  true,  true,  false);
        _maze[(3,1)] = (true,  false, false, false);
        _maze[(4,1)] = (false, true,  true,  false);
        _maze[(5,1)] = (true,  true,  true,  false);
        _maze[(6,1)] = (true,  false, true,  false);

        _maze[(1,2)] = (false, true,  true,  true);
        _maze[(2,2)] = (true,  true,  true,  true);
        _maze[(3,2)] = (true,  false, false, true);
        _maze[(4,2)] = (false, true,  false, true);
        _maze[(5,2)] = (true,  true,  true,  true);
        _maze[(6,2)] = (true,  false, false, true);

        _maze[(1,3)] = (false, false, true,  true);
        _maze[(2,3)] = (false, true,  true,  true);
        _maze[(3,3)] = (true,  false, false, true);
        _maze[(4,3)] = (false, true,  true,  true);
        _maze[(5,3)] = (true,  true,  true,  true);
        _maze[(6,3)] = (true,  false, true,  true);

        _maze[(1,4)] = (false, true,  true,  true);
        _maze[(2,4)] = (true,  true,  true,  true);
        _maze[(3,4)] = (true,  true,  true,  true);
        _maze[(4,4)] = (true,  true,  true,  true);
        _maze[(5,4)] = (true,  true,  true,  true);
        _maze[(6,4)] = (true,  false, false, true);

        _maze[(1,5)] = (false, true,  true,  true);
        _maze[(2,5)] = (true,  false, true,  true);
        _maze[(3,5)] = (false, true,  true,  true);
        _maze[(4,5)] = (true,  false, true,  true);
        _maze[(5,5)] = (false, true,  true,  true);
        _maze[(6,5)] = (true,  false, false, true);

        _maze[(1,6)] = (false, true,  false, true);
        _maze[(2,6)] = (true,  false, false, true);
        _maze[(3,6)] = (false, true,  false, true);
        _maze[(4,6)] = (true,  false, false, true);
        _maze[(5,6)] = (false, true,  false, true);
        _maze[(6,6)] = (true,  false, false, true);
    }
}
