﻿#region licence
// The MIT License (MIT)
// 
// Filename: Tests10CheckKeyFind.cs
// Date Created: 2014/07/16
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
using System.Diagnostics;
using System.Linq;
using GenericServices.Core.Internal;
using NUnit.Framework;
using Tests.DataClasses;
using Tests.DataClasses.Concrete;
using Tests.DTOs.Concrete;
using Tests.Helpers;

namespace Tests.UnitTests.Group02DataClasses
{
    class Tests10CheckKeysManipulation
    {

        [Test]
        public void Check01FindPostKeyOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                DataLayerInitialise.InitialiseThis();
                var x = db.Posts.Count();

                //ATTEMPT
                timer.Start();
                var keys = db.GetKeyProperties<Post>();
                timer.Stop();

                Console.WriteLine("took {0:f3} ms", 1000.0 * timer.ElapsedTicks / Stopwatch.Frequency);
                //VERIFY
                keys.Count.ShouldEqual(1);
                keys.First().Name.ShouldEqual("PostId");
            }
        }

        [Test]
        public void Check02FindPostKeyAgainOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                DataLayerInitialise.InitialiseThis();
                var x = db.Posts.Count();

                //ATTEMPT
                timer.Start();
                var keys = db.GetKeyProperties<Post>();
                timer.Stop();

                Console.WriteLine("took {0:f3} ms", 1000.0 * timer.ElapsedTicks / Stopwatch.Frequency);
                //VERIFY
                keys.Count.ShouldEqual(1);
                keys.First().Name.ShouldEqual("PostId");
            }
        }

        [Test]
        public void Check05FindPostTagGradeKeyOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                DataLayerInitialise.InitialiseThis();

                //ATTEMPT
                var keys = db.GetKeyProperties<PostTagGrade>();

                //VERIFY
                keys.Count.ShouldEqual(2);
                keys.First().Name.ShouldEqual("PostId");
                keys.Last().Name.ShouldEqual("TagId");
            }
        }

        //--------------------------------------------------------------------------

        [Test]
        public void Check10PostCopyKeysBackToDtoOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                var post = new Post{PostId = 123};
                var dto = new DetailPostDto();

                //ATTEMPT
                timer.Start();
                dto.AfterCreateCopyBackKeysToDtoIfPresent(db, post);
                timer.Stop();

                Console.WriteLine("took {0:f3} ms", 1000.0 * timer.ElapsedTicks / Stopwatch.Frequency);
                //VERIFY
                dto.PostId.ShouldEqual(post.PostId);
            }
        }

        [Test]
        public void Check11PostTagGradesCopyKeysBackToDtoOk()
        {
            using (var db = new SampleWebAppDb())
            {
                //SETUP
                var timer = new Stopwatch();
                var postTag = new PostTagGrade { PostId = 123, TagId = 456};
                var dto = new SimplePostTagGradeDto();

                //ATTEMPT
                timer.Start();
                dto.AfterCreateCopyBackKeysToDtoIfPresent(db, postTag);
                timer.Stop();

                Console.WriteLine("took {0:f3} ms", 1000.0 * timer.ElapsedTicks / Stopwatch.Frequency);
                //VERIFY
                dto.PostId.ShouldEqual(postTag.PostId);
                dto.TagId.ShouldEqual(postTag.TagId);
            }
        }
    }
}
