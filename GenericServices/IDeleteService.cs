#region licence
// The MIT License (MIT)
// 
// Filename: IDeleteService.cs
// Date Created: 2014/05/19
// 
// Copyright (c) 2014 Jon Smith (www.selectiveanalytics.com & www.thereformedprogrammer.net)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;
using GenericLibsBase;

namespace GenericServices
{
    public interface IDeleteService
    {
        /// <summary>
        /// This will delete an item from the database
        /// </summary>
        /// <param name="keys">The keys must be given in the same order as entity framework has them</param>
        /// <returns></returns>
        ISuccessOrErrors Delete<TEntity>(params object[] keys) where TEntity : class;

        /// <summary>
        /// This allows a developer to delete an entity plus any of its relationships.
        /// The first part of the method finds the given entity using the provided keys.
        /// It then calls the deleteRelationships method which should remove the extra relationships
        /// </summary>
        /// <param name="removeRelationships">method which is handed the DbContext and the found entity.
        /// It should then remove any relationships on this entity that it wants to.
        /// It returns a status, if IsValid then calls SaveChangesWithChecking</param>
        /// <param name="keys">The keys must be given in the same order as entity framework has them</param>
        /// <returns></returns>
        ISuccessOrErrors DeleteWithRelationships<TEntity>(
            Func<IGenericServicesDbContext, TEntity, ISuccessOrErrors> removeRelationships,
            params object[] keys) where TEntity : class;
    }
}