// Copyright © 2009 by Christoph Richner. All rights are reserved.
// 
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// 
// website http://www.raccoom.net, email support@raccoom.net, msn chrisdarebell@msn.com

namespace Raccoom.Windows.Forms
{
    /// <summary>
    /// Inherits from <see cref="System.Windows.Forms.TreeNode"/> and extends it dummy node handling and a Refresh method.
    /// </summary>
    [System.Serializable]
    public class TreeNodeBase : System.Windows.Forms.TreeNode
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the TreeNodeBase class using the specified serialization information and context. 
        /// </summary>
        /// <param name="info">A SerializationInfo containing the data to deserialize the class.</param>
        /// <param name="context">The StreamingContext containing the source and destination of the serialized stream.</param>
        protected TreeNodeBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Initializes a new instance of the TreeNodeBase class.
        /// </summary>
        public TreeNodeBase(string text)
            : base(text)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TreeNodeBase class.
        /// </summary>
        public TreeNodeBase(string text, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex)
        {
        }

        #endregion

        #region public interface

        /// <summary>
        /// Gets a value indicating whether the tree node can be refreshed.
        /// </summary>
        public virtual bool CanRefresh
        {
            get { return true; }
        }

        /// <summary>
        /// Collapse the node, clears all child nodes, add a dummy node and expand it again.
        /// </summary>
        public virtual void Refresh()
        {
            // do it only if we can refresh the node and there are valid child nodes.
            if (!CanRefresh || HasDummyNode) return;
            //			
            try
            {
                if (TreeView != null)
                {
                    TreeView.UseWaitCursor = true;
                    TreeView.BeginUpdate();
                }
                //
                this.Collapse();
                this.Nodes.Clear();
                this.AddDummyNode();
                this.Expand();
            }
            finally
            {
                if (TreeView != null)
                {
                    TreeView.EndUpdate();
                    TreeView.UseWaitCursor = false;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the tree node owns a dummy node.
        /// </summary>
        public virtual bool HasDummyNode
        {
            get { return (Nodes.Count > 0 && Nodes[0].Text == "@@Dummy@@"); }
        }

        /// <summary>
        /// Adds a dummy node to the parent node
        /// </summary>		
        public virtual void AddDummyNode()
        {
            Nodes.Add(new TreeNodePath("@@Dummy@@", false));
        }

        /// <summary>
        /// Removes the dummy node from the parent node.
        /// </summary>		
        public virtual void RemoveDummyNode()
        {
            if ((Nodes.Count == 1) && (Nodes[0].Text == "@@Dummy@@"))
            {
                Nodes[0].Remove();
            }
        }

        #endregion
    }

    /// <summary>
    /// Extends the <c>TreeNode</c> type with a path property. This node type is used by <see cref="TreeViewFolderBrowser"/>
    /// </summary>
    [System.Serializable]
    public class TreeNodePath : TreeNodeBase
    {
        #region fields

        /// <summary>Specifiy that this node instance represent a special folder.</summary>
        private readonly bool _isSpecialFolder;

        /// <summary>
        /// File or directory path information
        /// </summary>
        private string _path;

        #endregion fiels

        #region constructor
        /// <summary>
        /// Initializes a new instance of the TreeNodePath class using the specified serialization information and context. 
        /// </summary>
        /// <param name="info">A SerializationInfo containing the data to deserialize the class.</param>
        /// <param name="context">The StreamingContext containing the source and destination of the serialized stream.</param>
        protected TreeNodePath(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Initializes a new instance of the TreeNodePath class.
        /// </summary>
        /// <param name="text">The label Text of the new tree node. </param>
        /// <param name="isSpecialFolder">Indicates if this folder is a special folder and cannot be refreshed the common way.</param>
        public TreeNodePath(string text, bool isSpecialFolder)
            : base(text)
        {
            this._isSpecialFolder = isSpecialFolder;
        }

        /// <summary>
        /// Initializes a new instance of the TreeNodePath class.
        /// </summary>
        /// <param name="text">The label Text of the new tree node. </param>
        /// <param name="imageIndex">The index value of Image to display when the tree node is unselected.</param>
        /// <param name="selectedImageIndex">The index value of Image to display when the tree node is selected.</param>
        /// <param name="isSpecialFolder">Indicates if this folder is a special folder and cannot be refreshed the common way.</param>
        public TreeNodePath(string text, bool isSpecialFolder, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex)
        {
            _isSpecialFolder = isSpecialFolder;
        }

        #endregion

        #region public interface

        /// <summary>
        /// Gets or sets this node as a special folder node.
        /// </summary>
        /// <remarks>
        /// SpecialFolder's are folder's which are defined by <see cref="System.Environment.SpecialFolder"/> enum.
        /// </remarks>
        public bool IsSpecialFolder
        {
            get { return _isSpecialFolder; }
        }

        /// <summary>
        /// Gets or sets the file or directory path information
        /// </summary>			
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        #endregion
    }
}