﻿using System.Collections;

namespace AngryFileManager;

public class ListViewColumnSorter : IComparer
{
    /// <summary>
    /// Specifies the column to be sorted
    /// </summary>
    private int _columnToSort;

    /// <summary>
    /// Specifies the order in which to sort (i.e. 'Ascending').
    /// </summary>
    private SortOrder _orderOfSort;

    /// <summary>
    /// Case insensitive comparer object
    /// </summary>
    private readonly CaseInsensitiveComparer _objectCompare;

    /// <summary>
    /// Class constructor. Initializes various elements
    /// </summary>
    public ListViewColumnSorter()
    {
        // Initialize the column to '0'
        _columnToSort = 0;

        // Initialize the sort order to 'none'
        _orderOfSort = SortOrder.None;

        // Initialize the CaseInsensitiveComparer object
        _objectCompare = new CaseInsensitiveComparer();
    }

    /// <summary>
    /// This method is inherited from the IComparer interface. It compares the two objects passed using a case insensitive comparison.
    /// </summary>
    /// <param name="x">First object to be compared</param>
    /// <param name="y">Second object to be compared</param>
    /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    public int Compare(object x, object y)
    {
        // Cast the objects to be compared to ListViewItem objects
        var listviewX = (ListViewItem)x;
        var listviewY = (ListViewItem)y;
            
        // Compare the two items
        var compareResult = _objectCompare.Compare(listviewX.SubItems[_columnToSort].Text,
            listviewY.SubItems[_columnToSort].Text);

        return _orderOfSort switch
        {
            // Calculate correct return value based on object comparison
            SortOrder.Ascending => compareResult,
            SortOrder.Descending => (-compareResult),
            _ => 0
        };
    }

    /// <summary>
    /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    /// </summary>
    public int SortColumn
    {
        set => _columnToSort = value;
        get => _columnToSort;
    }

    /// <summary>
    /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    /// </summary>
    public SortOrder Order
    {
        set => _orderOfSort = value;
        get => _orderOfSort;
    }
}