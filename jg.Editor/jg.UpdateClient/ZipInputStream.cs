// ZipInputStream.cs
//
// Copyright (C) 2001 Mike Krueger
// Copyright (C) 2004 John Reilly
//
// This file was translated from java, it was part of the GNU Classpath
// Copyright (C) 2001 Free Software Foundation, Inc.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// Linking this library statically or dynamically with other modules is
// making a combined work based on this library.  Thus, the terms and
// conditions of the GNU General Public License cover the whole
// combination.
// 
// As a special exception, the copyright holders of this library give you
// permission to link this library with independent modules to produce an
// executable, regardless of the license terms of these independent
// modules, and to copy and distribute the resulting executable under
// terms of your choice, provided that you also meet, for each linked
// independent module, the terms and conditions of the license of that
// module.  An independent module is a module which is not derived from
// or based on this library.  If you modify this library, you may extend
// this exception to your version of the library, but you are not
// obligated to do so.  If you do not wish to do so, delete this
// exception statement from your version.

using System;
using System.Text;
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

using ICSharpCode.SharpZipLib.Encryption;
using ICSharpCode.SharpZipLib.Zip;

namespace jg.UpdateClient
{
    /// <summary>
    /// Zipѹ�����ѹ�� 
    /// </summary>
    public class ZipHelper
    {

        public delegate void OnProcess(double value);
        public event OnProcess Process = null;


        /// <summary>
        /// ѹ�������ļ�
        /// </summary>
        /// <param name="fileToZip">Ҫѹ�����ļ�</param>
        /// <param name="zipedFile">ѹ������ļ�</param>
        /// <param name="compressionLevel">ѹ���ȼ�</param>
        /// <param name="blockSize">ÿ��д���С</param>
        public void ZipFile(string fileToZip, string zipedFile, int compressionLevel, int blockSize)
        {
            //����ļ�û���ҵ����򱨴�
            if (!System.IO.File.Exists(fileToZip))
            {
                throw new System.IO.FileNotFoundException("ָ��Ҫѹ�����ļ�: " + fileToZip + " ������!");
            }

            using (System.IO.FileStream ZipFile = System.IO.File.Create(zipedFile))
            {
                using (ZipOutputStream ZipStream = new ZipOutputStream(ZipFile))
                {
                    using (System.IO.FileStream StreamToZip = new System.IO.FileStream(fileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        string fileName = fileToZip.Substring(fileToZip.LastIndexOf("\\") + 1);

                        ZipEntry ZipEntry = new ZipEntry(fileName);

                        ZipStream.PutNextEntry(ZipEntry);

                        ZipStream.SetLevel(compressionLevel);

                        byte[] buffer = new byte[blockSize];

                        int sizeRead = 0;

                        try
                        {
                            do
                            {
                                sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                                ZipStream.Write(buffer, 0, sizeRead);
                            }
                            while (sizeRead > 0);
                        }
                        catch (System.Exception ex)
                        {
                            throw ex;
                        }

                        StreamToZip.Close();
                    }

                    ZipStream.Finish();
                    ZipStream.Close();
                }

                ZipFile.Close();
            }
        }

        /// <summary>
        /// ѹ�������ļ�
        /// </summary>
        /// <param name="fileToZip">Ҫ����ѹ�����ļ���</param>
        /// <param name="zipedFile">ѹ�������ɵ�ѹ���ļ���</param>
        public void ZipFile(string fileToZip, string zipedFile)
        {
            //����ļ�û���ҵ����򱨴�
            if (!File.Exists(fileToZip))
            {
                throw new System.IO.FileNotFoundException("ָ��Ҫѹ�����ļ�: " + fileToZip + " ������!");
            }

            using (FileStream fs = File.OpenRead(fileToZip))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                using (FileStream ZipFile = File.Create(zipedFile))
                {
                    using (ZipOutputStream ZipStream = new ZipOutputStream(ZipFile))
                    {
                        string fileName = fileToZip.Substring(fileToZip.LastIndexOf("\\") + 1);
                        ZipEntry ZipEntry = new ZipEntry(fileName);
                        ZipStream.PutNextEntry(ZipEntry);
                        ZipStream.SetLevel(5);

                        ZipStream.Write(buffer, 0, buffer.Length);
                        ZipStream.Finish();
                        ZipStream.Close();
                    }
                }
            }
        }

        /// <summary>
        /// ѹ�����Ŀ¼
        /// </summary>
        /// <param name="strDirectory">The directory.</param>
        /// <param name="zipedFile">The ziped file.</param>
        public void ZipFileDirectory(string strDirectory, string zipedFile)
        {
            using (System.IO.FileStream ZipFile = System.IO.File.Create(zipedFile))
            {
                using (ZipOutputStream s = new ZipOutputStream(ZipFile))
                {
                    ZipSetp(strDirectory, s, "");
                }
            }
        }

        /// <summary>
        /// �ݹ����Ŀ¼
        /// </summary>
        /// <param name="strDirectory">The directory.</param>
        /// <param name="s">The ZipOutputStream Object.</param>
        /// <param name="parentPath">The parent path.</param>
        private void ZipSetp(string strDirectory, ZipOutputStream s, string parentPath)
        {
            if (strDirectory[strDirectory.Length - 1] != Path.DirectorySeparatorChar)
            {
                strDirectory += Path.DirectorySeparatorChar;
            }
            Crc32 crc = new Crc32();

            string[] filenames = Directory.GetFileSystemEntries(strDirectory);

            foreach (string file in filenames)// �������е��ļ���Ŀ¼
            {

                if (Directory.Exists(file))// �ȵ���Ŀ¼��������������Ŀ¼�͵ݹ�Copy��Ŀ¼������ļ�
                {
                    string pPath = parentPath;
                    pPath += file.Substring(file.LastIndexOf("\\") + 1);
                    pPath += "\\";
                    ZipSetp(file, s, pPath);
                }

                else // ����ֱ��ѹ���ļ�
                {
                    //��ѹ���ļ�
                    using (FileStream fs = File.OpenRead(file))
                    {

                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);

                        string fileName = parentPath + file.Substring(file.LastIndexOf("\\") + 1);
                        ZipEntry entry = new ZipEntry(fileName);

                        entry.DateTime = DateTime.Now;
                        entry.Size = fs.Length;

                        fs.Close();

                        crc.Reset();
                        crc.Update(buffer);

                        entry.Crc = crc.Value;
                        s.PutNextEntry(entry);

                        s.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        /// <summary>
        /// ��ѹ��һ�� zip �ļ���
        /// </summary>
        /// <param name="zipedFile">The ziped file.</param>
        /// <param name="strDirectory">The STR directory.</param>
        /// <param name="password">zip �ļ������롣</param>
        /// <param name="overWrite">�Ƿ񸲸��Ѵ��ڵ��ļ���</param>
        public void UnZip(string zipedFile, string strDirectory, string password, bool overWrite)
        {
            long maxLength, value = 0;
            if (strDirectory == "")
                strDirectory = Directory.GetCurrentDirectory();
            if (!strDirectory.EndsWith("\\"))
                strDirectory = strDirectory + "\\";
            FileInfo fileInfo = new FileInfo(zipedFile);
            maxLength = fileInfo.Length;

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipedFile)))
            {
                
                s.Password = password;
                ZipEntry theEntry;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = "";
                    string pathToZip = "";
                    pathToZip = theEntry.Name;

                    if (pathToZip != "")
                        directoryName = Path.GetDirectoryName(pathToZip) + "\\";

                    string fileName = Path.GetFileName(pathToZip);

                    Directory.CreateDirectory(strDirectory + directoryName);

                    if (fileName != "")
                    {
                        if ((File.Exists(strDirectory + directoryName + fileName) && overWrite) || (!File.Exists(strDirectory + directoryName + fileName)))
                        {
                            using (FileStream streamWriter = File.Create(strDirectory + directoryName + fileName))
                            {
                                int size = 1024 * 8;
                                byte[] data = new byte[size];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);

                                    if (Process != null) Process(Convert.ToDouble((value += size)) / (double)maxLength);
                                    if (size > 0)
                                        streamWriter.Write(data, 0, size);
                                    else
                                        break;
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                }

                s.Close();
            }
        }

    }
}