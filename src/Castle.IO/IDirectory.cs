﻿#region license

// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;

namespace Castle.IO
{
	public interface IDirectory : IFileSystemItem<IDirectory>
	{
		IDirectory GetDirectory(string directoryName);
		IFile GetFile(string fileName);
		IEnumerable<IFile> Files();
		IEnumerable<IDirectory> Directories();
		IEnumerable<IFile> Files(string filter, SearchScope scope);
		IEnumerable<IDirectory> Directories(string filter, SearchScope scope);
		bool IsHardLink { get; }
		

		IDirectory LinkTo(string path);

		IDirectory Target { get; }

		IDisposable FileChanges(string filter = "*", bool includeSubdirectories = false, Action<IFile> created = null,
		                        Action<IFile> modified = null, Action<IFile> deleted = null, Action<IFile> renamed = null);
	}
}