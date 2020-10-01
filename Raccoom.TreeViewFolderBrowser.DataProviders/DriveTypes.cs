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
	/// Defines the DriveTypes used for Win32_LogicalDisk<seealso cref="TreeViewFolderBrowser"/>.This enumeration can be treated as a bit field, that is, a set of flags.
	/// </summary>
	[System.Flags]
	[System.ComponentModel.Editor(typeof (Raccoom.Windows.Forms.Design.EnumEditor), typeof (System.Drawing.Design.UITypeEditor))]
	public enum DriveTypes
	{
		/// <summary>All drive types</summary>
		All = NoRootDirectory | RemovableDisk | LocalDisk | NetworkDrive | CompactDisc | RAMDisk,
		/// <summary>
		/// NoRootDirectory
		/// </summary>
		NoRootDirectory = 0x0001,
		/// <summary>
		/// Drive has removable media. This includes all floppy drives and many other varieties of storage devices.
		/// </summary>
		RemovableDisk = 0x0002,
		/// <summary>
		/// Drive has fixed (nonremovable) media. This includes all hard drives, including hard drives that are removable.
		/// </summary>
		LocalDisk = 0x0004,
		/// <summary>
		/// Network drives. This includes drives shared anywhere on a network.
		/// </summary>
		NetworkDrive = 0x0008,
		/// <summary>
		/// Drive is a CD-ROM. No distinction is made between read-only and read/write CD-ROM drives.
		/// </summary>
		CompactDisc = 0x0020,
		/// <summary>
		/// Drive is a block of Random Access Memory (RAM) on the local computer that behaves like a disk drive.
		/// </summary>
		RAMDisk = 0x0040
	}

	/// <summary>
	/// Defines the DriveTypes used for Win32_LogicalDisk<seealso cref="TreeViewFolderBrowser"/>.This enumeration can a<b>not</b> be treated as a bit field
	/// </summary>
	public enum Win32_LogicalDiskDriveTypes
	{
		/// <summary>
		/// NoRootDirectory
		/// </summary>
		NoRootDirectory = 1,
		/// <summary>
		/// Drive has removable media. This includes all floppy drives and many other varieties of storage devices.
		/// </summary>
		RemovableDisk,
		/// <summary>
		/// Drive has fixed (nonremovable) media. This includes all hard drives, including hard drives that are removable.
		/// </summary>
		LocalDisk,
		/// <summary>
		/// Network drives. This includes drives shared anywhere on a network.
		/// </summary>
		NetworkDrive,
		/// <summary>
		/// Drive is a CD-ROM. No distinction is made between read-only and read/write CD-ROM drives.
		/// </summary>
		CompactDisc,
		/// <summary>
		/// Drive is a block of Random Access Memory (RAM) on the local computer that behaves like a disk drive.
		/// </summary>
		RAMDisk
	}
}