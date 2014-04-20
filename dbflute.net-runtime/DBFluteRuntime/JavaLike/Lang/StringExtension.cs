using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace DBFluteRuntime.JavaLike.Lang
{
    /// <summary>
    /// as java.lang.String class
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        ///* Returns the <code>char</code> value at the
        ///* specified index. An index ranges from <code>0</code> to
        ///* <code>length() - 1</code>. The first <code>char</code> value of the sequence
        ///* is at index <code>0</code>, the next at index <code>1</code>,
        ///* and so on, as for array indexing.
        ///*
        ///* <p>If the <code>char</code> value specified by the index is a
        ///* <a href="Character.html#unicode">surrogate</a>, the surrogate
        ///* value is returned.
        ///*
        ///* @param      index   the index of the <code>char</code> value.
        ///* @return     the <code>char</code> value at the specified index of this string.
        ///*             The first <code>char</code> value is at index <code>0</code>.
        ///* @exception  IndexOutOfBoundsException  if the <code>index</code>
        ///*             argument is negative or not less than the length of this
        ///*             string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static char CharAt(this string s, int index)
        {
            char[] values = s.ToCharArray();
            if (index < 0 || index >= values.Length)
            {
                throw new IndexOutOfRangeException(string.Format("index={0}", index));
            }
            // Javaではoffsetの加算が入るが、単発で使う場合は不要なため省略
            return values[index];
        }

        /// <summary>
        ////**
        /// * Returns the character (Unicode code point) at the specified
        /// * index. The index refers to <code>char</code> values
        /// * (Unicode code units) and ranges from <code>0</code> to
        /// * {@link #length()}<code> - 1</code>.
        /// *
        /// * <p> If the <code>char</code> value specified at the given index
        /// * is in the high-surrogate range, the following index is less
        /// * than the length of this <code>String</code>, and the
        /// * <code>char</code> value at the following index is in the
        /// * low-surrogate range, then the supplementary code point
        /// * corresponding to this surrogate pair is returned. Otherwise,
        /// * the <code>char</code> value at the given index is returned.
        /// *
        /// * @param      index the index to the <code>char</code> values
        /// * @return     the code point value of the character at the
        /// *             <code>index</code>
        /// * @exception  IndexOutOfBoundsException  if the <code>index</code>
        /// *             argument is negative or not less than the length of this
        /// *             string.
        /// * @since      1.5
        /// */
        /// </summary>
        /// <param name="s"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int CodePointAt(this string s, int index)
        {
            throw new NotSupportedException("[string] is not supported [CodePointAt] method.");
        }

        /// <summary>
        ////**
        /// * Returns the character (Unicode code point) before the specified
        /// * index. The index refers to <code>char</code> values
        /// * (Unicode code units) and ranges from <code>1</code> to {@link
        /// * CharSequence#length() length}.
        /// *
        /// * <p> If the <code>char</code> value at <code>(index - 1)</code>
        /// * is in the low-surrogate range, <code>(index - 2)</code> is not
        /// * negative, and the <code>char</code> value at <code>(index -
        /// * 2)</code> is in the high-surrogate range, then the
        /// * supplementary code point value of the surrogate pair is
        /// * returned. If the <code>char</code> value at <code>index -
        /// * 1</code> is an unpaired low-surrogate or a high-surrogate, the
        /// * surrogate value is returned.
        /// *
        /// * @param     index the index following the code point that should be returned
        /// * @return    the Unicode code point value before the given index.
        /// * @exception IndexOutOfBoundsException if the <code>index</code>
        /// *            argument is less than 1 or greater than the length
        /// *            of this string.
        /// * @since     1.5
        /// */
        /// </summary>
        /// <param name="s"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int CodePointBefore(this string s, int index)
        {
            throw new NotSupportedException("[string] is not supported [CodePointBefore] method.");
        }

        /**
         * Returns the number of Unicode code points in the specified text
         * range of this <code>String</code>. The text range begins at the
         * specified <code>beginIndex</code> and extends to the
         * <code>char</code> at index <code>endIndex - 1</code>. Thus the
         * length (in <code>char</code>s) of the text range is
         * <code>endIndex-beginIndex</code>. Unpaired surrogates within
         * the text range count as one code point each.
         *
         * @param beginIndex the index to the first <code>char</code> of
         * the text range.
         * @param endIndex the index after the last <code>char</code> of
         * the text range.
         * @return the number of Unicode code points in the specified text
         * range
         * @exception IndexOutOfBoundsException if the
         * <code>beginIndex</code> is negative, or <code>endIndex</code>
         * is larger than the length of this <code>String</code>, or
         * <code>beginIndex</code> is larger than <code>endIndex</code>.
         * @since  1.5
         */
        public static int CodePointCount(this string s, int beginIndex, int endIndex)
        {
            throw new NotSupportedException("[string] is not supported [CodePointCount] method.");
        }

        /**
         * Returns the index within this <code>String</code> that is
         * offset from the given <code>index</code> by
         * <code>codePointOffset</code> code points. Unpaired surrogates
         * within the text range given by <code>index</code> and
         * <code>codePointOffset</code> count as one code point each.
         *
         * @param index the index to be offset
         * @param codePointOffset the offset in code points
         * @return the index within this <code>String</code>
         * @exception IndexOutOfBoundsException if <code>index</code>
         *   is negative or larger then the length of this
         *   <code>String</code>, or if <code>codePointOffset</code> is positive
         *   and the substring starting with <code>index</code> has fewer
         *   than <code>codePointOffset</code> code points,
         *   or if <code>codePointOffset</code> is negative and the substring
         *   before <code>index</code> has fewer than the absolute value
         *   of <code>codePointOffset</code> code points.
         * @since 1.5
         */
        public static int OffsetByCodePoints(this string s, int index, int codePointOffset)
        {
            throw new NotSupportedException("[string] is not supported [OffsetByCodePoints] method.");
        }

        /**
         * Copy characters from this string into dst starting at dstBegin.
         * This method doesn't perform any range checking.
         */
        public static void GetChars(this string s, char[] dst, int dstBegin)
        {
            int count = s.Length;
            if (count > dst.Length)
            {
                count = dst.Length;
            }
            s.CopyTo(0, dst, dstBegin, count);
        }

        /**
         * Copies characters from this string into the destination character
         * array.
         * <p>
         * The first character to be copied is at index <code>srcBegin</code>;
         * the last character to be copied is at index <code>srcEnd-1</code>
         * (thus the total number of characters to be copied is
         * <code>srcEnd-srcBegin</code>). The characters are copied into the
         * subarray of <code>dst</code> starting at index <code>dstBegin</code>
         * and ending at index:
         * <p><blockquote><pre>
         *     dstbegin + (srcEnd-srcBegin) - 1
         * </pre></blockquote>
         *
         * @param      srcBegin   index of the first character in the string
         *                        to copy.
         * @param      srcEnd     index after the last character in the string
         *                        to copy.
         * @param      dst        the destination array.
         * @param      dstBegin   the start offset in the destination array.
         * @exception IndexOutOfBoundsException If any of the following
         *            is true:
         *            <ul><li><code>srcBegin</code> is negative.
         *            <li><code>srcBegin</code> is greater than <code>srcEnd</code>
         *            <li><code>srcEnd</code> is greater than the length of this
         *                string
         *            <li><code>dstBegin</code> is negative
         *            <li><code>dstBegin+(srcEnd-srcBegin)</code> is larger than
         *                <code>dst.length</code></ul>
         */
        public static void GetChars(this string s, int srcBegin, int srcEnd, char[] dst, int dstBegin)
        {
            if (srcBegin < 0)
            {
                throw new IndexOutOfRangeException(string.Format("[srcBegin] = {0}", srcBegin));
            }
            if (srcEnd >= s.Length)
            {
                throw new IndexOutOfRangeException(string.Format("[srcEnd] = {0}", srcEnd));
            }
            if (srcBegin > srcEnd)
            {
                throw new IndexOutOfRangeException(string.Format("[CopyCount] = {0}", srcEnd - srcBegin));
            }
            s.CopyTo(srcBegin, dst, dstBegin, srcEnd - srcBegin);
        }

        /**
         * Encodes this {@code String} into a sequence of bytes using the named
         * charset, storing the result into a new byte array.
         *
         * <p> The behavior of this method when this string cannot be encoded in
         * the given charset is unspecified.  The {@link
         * java.nio.charset.CharsetEncoder} class should be used when more control
         * over the encoding process is required.
         *
         * @param  charsetName
         *         The name of a supported {@linkplain java.nio.charset.Charset
         *         charset}
         *
         * @return  The resultant byte array
         *
         * @throws  UnsupportedEncodingException
         *          If the named charset is not supported
         *
         * @since  JDK1.1
         */
        public static byte[] GetBytes(this string s, string charsetName)
        {
            if (charsetName == null)
            {
                throw new NullReferenceException("charsetName");
            }
            return Encoding.GetEncoding(charsetName).GetBytes(s);
        }

        /**
         * Encodes this {@code String} into a sequence of bytes using the given
         * {@linkplain java.nio.charset.Charset charset}, storing the result into a
         * new byte array.
         *
         * <p> This method always replaces malformed-input and unmappable-character
         * sequences with this charset's default replacement byte array.  The
         * {@link java.nio.charset.CharsetEncoder} class should be used when more
         * control over the encoding process is required.
         *
         * @param  charset
         *         The {@linkplain java.nio.charset.Charset} to be used to encode
         *         the {@code String}
         *
         * @return  The resultant byte array
         *
         * @since  1.6
         */
        public static byte[] GetBytes(this string s, Encoding charset)
        {
            if (charset == null)
            {
                throw new NullReferenceException("charsetName");
            }
            return charset.GetBytes(s);
        }

        /**
         * Encodes this {@code String} into a sequence of bytes using the
         * platform's default charset, storing the result into a new byte array.
         *
         * <p> The behavior of this method when this string cannot be encoded in
         * the default charset is unspecified.  The {@link
         * java.nio.charset.CharsetEncoder} class should be used when more control
         * over the encoding process is required.
         *
         * @return  The resultant byte array
         *
         * @since      JDK1.1
         */
        public static byte[] GetBytes(this string s)
        {
            return Encoding.Unicode.GetBytes(s);
        }

        // * equals is already implemented.

        /**
         * Compares this string to the specified {@code StringBuffer}.  The result
         * is {@code true} if and only if this {@code String} represents the same
         * sequence of characters as the specified {@code StringBuffer}.
         *
         * @param  sb
         *         The {@code StringBuffer} to compare this {@code String} against
         *
         * @return  {@code true} if this {@code String} represents the same
         *          sequence of characters as the specified {@code StringBuffer},
         *          {@code false} otherwise
         *
         * @since  1.4
         */
        public static bool ContentEquals(this string s, StringBuilder sb)
        {
            throw new NotSupportedException("[string] is not supported [ContentEquals] method.");
        }

        /**
         * Compares this string to the specified {@code CharSequence}.  The result
         * is {@code true} if and only if this {@code String} represents the same
         * sequence of char values as the specified sequence.
         *
         * @param  cs
         *         The sequence to compare this {@code String} against
         *
         * @return  {@code true} if this {@code String} represents the same
         *          sequence of char values as the specified sequence, {@code
         *          false} otherwise
         *
         * @since  1.5
         */
        public static bool ContentEquals(this string s, CharEnumerator cs)
        {
            throw new NotSupportedException("[string] is not supported [ContentEquals] method.");
        }

        /**
         * Compares this {@code String} to another {@code String}, ignoring case
         * considerations.  Two strings are considered equal ignoring case if they
         * are of the same length and corresponding characters in the two strings
         * are equal ignoring case.
         *
         * <p> Two characters {@code c1} and {@code c2} are considered the same
         * ignoring case if at least one of the following is true:
         * <ul>
         *   <li> The two characters are the same (as compared by the
         *        {@code ==} operator)
         *   <li> Applying the method {@link
         *        java.lang.Character#toUpperCase(char)} to each character
         *        produces the same result
         *   <li> Applying the method {@link
         *        java.lang.Character#toLowerCase(char)} to each character
         *        produces the same result
         * </ul>
         *
         * @param  anotherString
         *         The {@code String} to compare this {@code String} against
         *
         * @return  {@code true} if the argument is not {@code null} and it
         *          represents an equivalent {@code String} ignoring case; {@code
         *          false} otherwise
         *
         * @see  #equals(Object)
         */
        public static bool EqualsIgnoreCase(this string s, string anotherString)
        {
            return s.Equals(anotherString, StringComparison.OrdinalIgnoreCase);
        }

        // * compareTo is already implemented.
        // CASE_INSENTIVE_ORDER is not supported.

        /**
         * Compares two strings lexicographically, ignoring case
         * differences. This method returns an integer whose sign is that of
         * calling <code>compareTo</code> with normalized versions of the strings
         * where case differences have been eliminated by calling
         * <code>Character.toLowerCase(Character.toUpperCase(character))</code> on
         * each character.
         * <p>
         * Note that this method does <em>not</em> take locale into account,
         * and will result in an unsatisfactory ordering for certain locales.
         * The java.text package provides <em>collators</em> to allow
         * locale-sensitive ordering.
         *
         * @param   str   the <code>String</code> to be compared.
         * @return  a negative integer, zero, or a positive integer as the
         *		specified String is greater than, equal to, or less
         *		than this String, ignoring case considerations.
         * @see     java.text.Collator#compare(String, String)
         * @since   1.2
         */
        public static int CompareToIgnoreCase(this string s, string str)
        {
            throw new NotSupportedException("[string] is not supported [CompareToIgnoreCase] method.");
        }

        /**
         * Tests if two string regions are equal.
         * <p>
         * A substring of this <tt>String</tt> object is compared to a substring
         * of the argument other. The result is true if these substrings
         * represent identical character sequences. The substring of this
         * <tt>String</tt> object to be compared begins at index <tt>toffset</tt>
         * and has length <tt>len</tt>. The substring of other to be compared
         * begins at index <tt>ooffset</tt> and has length <tt>len</tt>. The
         * result is <tt>false</tt> if and only if at least one of the following
         * is true:
         * <ul><li><tt>toffset</tt> is negative.
         * <li><tt>ooffset</tt> is negative.
         * <li><tt>toffset+len</tt> is greater than the length of this
         * <tt>String</tt> object.
         * <li><tt>ooffset+len</tt> is greater than the length of the other
         * argument.
         * <li>There is some nonnegative integer <i>k</i> less than <tt>len</tt>
         * such that:
         * <tt>this.charAt(toffset+<i>k</i>)&nbsp;!=&nbsp;other.charAt(ooffset+<i>k</i>)</tt>
         * </ul>
         *
         * @param   toffset   the starting offset of the subregion in this string.
         * @param   other     the string argument.
         * @param   ooffset   the starting offset of the subregion in the string
         *                    argument.
         * @param   len       the number of characters to compare.
         * @return  <code>true</code> if the specified subregion of this string
         *          exactly matches the specified subregion of the string argument;
         *          <code>false</code> otherwise.
         */
        public static bool RegionMatches(this string s, int toffset, string other, int ooffset, int len)
        {
            throw new NotSupportedException("[string] is not supported [RegionMatches] method.");
        }

        /**
         * Tests if two string regions are equal.
         * <p>
         * A substring of this <tt>String</tt> object is compared to a substring
         * of the argument <tt>other</tt>. The result is <tt>true</tt> if these
         * substrings represent character sequences that are the same, ignoring
         * case if and only if <tt>ignoreCase</tt> is true. The substring of
         * this <tt>String</tt> object to be compared begins at index
         * <tt>toffset</tt> and has length <tt>len</tt>. The substring of
         * <tt>other</tt> to be compared begins at index <tt>ooffset</tt> and
         * has length <tt>len</tt>. The result is <tt>false</tt> if and only if
         * at least one of the following is true:
         * <ul><li><tt>toffset</tt> is negative.
         * <li><tt>ooffset</tt> is negative.
         * <li><tt>toffset+len</tt> is greater than the length of this
         * <tt>String</tt> object.
         * <li><tt>ooffset+len</tt> is greater than the length of the other
         * argument.
         * <li><tt>ignoreCase</tt> is <tt>false</tt> and there is some nonnegative
         * integer <i>k</i> less than <tt>len</tt> such that:
         * <blockquote><pre>
         * this.charAt(toffset+k) != other.charAt(ooffset+k)
         * </pre></blockquote>
         * <li><tt>ignoreCase</tt> is <tt>true</tt> and there is some nonnegative
         * integer <i>k</i> less than <tt>len</tt> such that:
         * <blockquote><pre>
         * Character.toLowerCase(this.charAt(toffset+k)) !=
                   Character.toLowerCase(other.charAt(ooffset+k))
         * </pre></blockquote>
         * and:
         * <blockquote><pre>
         * Character.toUpperCase(this.charAt(toffset+k)) !=
         *         Character.toUpperCase(other.charAt(ooffset+k))
         * </pre></blockquote>
         * </ul>
         *
         * @param   ignoreCase   if <code>true</code>, ignore case when comparing
         *                       characters.
         * @param   toffset      the starting offset of the subregion in this
         *                       string.
         * @param   other        the string argument.
         * @param   ooffset      the starting offset of the subregion in the string
         *                       argument.
         * @param   len          the number of characters to compare.
         * @return  <code>true</code> if the specified subregion of this string
         *          matches the specified subregion of the string argument;
         *          <code>false</code> otherwise. Whether the matching is exact
         *          or case insensitive depends on the <code>ignoreCase</code>
         *          argument.
         */
        public static bool RegionMatches(this string s, bool ignoreCase, int toffset, string other, int ooffset, int len)
        {
            throw new NotSupportedException("[string] is not supported [RegionMatches] method.");
        }

        /**
         * Returns a hash code for this string. The hash code for a
         * <code>String</code> object is computed as
         * <blockquote><pre>
         * s[0]*31^(n-1) + s[1]*31^(n-2) + ... + s[n-1]
         * </pre></blockquote>
         * using <code>int</code> arithmetic, where <code>s[i]</code> is the
         * <i>i</i>th character of the string, <code>n</code> is the length of
         * the string, and <code>^</code> indicates exponentiation.
         * (The hash value of the empty string is zero.)
         *
         * @return  a hash code value for this object.
         */
        public static int HashCode(this string s)
        {
            return s.GetHashCode();
        }

        // * startsWith is already implemented.
        // * endsWith is already implemented.
        // * indexOf is already implemented.
        // * lastIndexOf is already implemented.
        // * subString is already implemented.

        /**
         * Returns a new character sequence that is a subsequence of this sequence.
         *
         * <p> An invocation of this method of the form
         *
         * <blockquote><pre>
         * str.subSequence(begin,&nbsp;end)</pre></blockquote>
         *
         * behaves in exactly the same way as the invocation
         *
         * <blockquote><pre>
         * str.substring(begin,&nbsp;end)</pre></blockquote>
         *
         * This method is defined so that the <tt>String</tt> class can implement
         * the {@link CharSequence} interface. </p>
         *
         * @param      beginIndex   the begin index, inclusive.
         * @param      endIndex     the end index, exclusive.
         * @return     the specified subsequence.
         *
         * @throws  IndexOutOfBoundsException
         *          if <tt>beginIndex</tt> or <tt>endIndex</tt> are negative,
         *          if <tt>endIndex</tt> is greater than <tt>length()</tt>,
         *          or if <tt>beginIndex</tt> is greater than <tt>startIndex</tt>
         *
         * @since 1.4
         * @spec JSR-51
         */
        public static CharEnumerator SubSequence(this string s, int beginIndex, int endIndex)
        {
            throw new NotSupportedException("[string] is not supported [SubSequence] method.");
        }

        /**
         * Tells whether or not this string matches the given <a
         * href="../util/regex/Pattern.html#sum">regular expression</a>.
         *
         * <p> An invocation of this method of the form
         * <i>str</i><tt>.matches(</tt><i>regex</i><tt>)</tt> yields exactly the
         * same result as the expression
         *
         * <blockquote><tt> {@link java.util.regex.Pattern}.{@link
         * java.util.regex.Pattern#matches(String,CharSequence)
         * matches}(</tt><i>regex</i><tt>,</tt> <i>str</i><tt>)</tt></blockquote>
         *
         * @param   regex
         *          the regular expression to which this string is to be matched
         *
         * @return  <tt>true</tt> if, and only if, this string matches the
         *          given regular expression
         *
         * @throws  PatternSyntaxException
         *          if the regular expression's syntax is invalid
         *
         * @see java.util.regex.Pattern
         *
         * @since 1.4
         * @spec JSR-51
         */
        public static bool Matches(this string s, string regex)
        {
            return Regex.IsMatch(s, regex);
        }

        // * concat is already implemented.
        // * replace is already implemented.
        // * contains is already implemented.

        /**
         * Replaces the first substring of this string that matches the given <a
         * href="../util/regex/Pattern.html#sum">regular expression</a> with the
         * given replacement.
         *
         * <p> An invocation of this method of the form
         * <i>str</i><tt>.replaceFirst(</tt><i>regex</i><tt>,</tt> <i>repl</i><tt>)</tt>
         * yields exactly the same result as the expression
         *
         * <blockquote><tt>
         * {@link java.util.regex.Pattern}.{@link java.util.regex.Pattern#compile
         * compile}(</tt><i>regex</i><tt>).{@link
         * java.util.regex.Pattern#matcher(java.lang.CharSequence)
         * matcher}(</tt><i>str</i><tt>).{@link java.util.regex.Matcher#replaceFirst
         * replaceFirst}(</tt><i>repl</i><tt>)</tt></blockquote>
         *
         *<p>
         * Note that backslashes (<tt>\</tt>) and dollar signs (<tt>$</tt>) in the
         * replacement string may cause the results to be different than if it were
         * being treated as a literal replacement string; see
         * {@link java.util.regex.Matcher#replaceFirst}.
         * Use {@link java.util.regex.Matcher#quoteReplacement} to suppress the special
         * meaning of these characters, if desired.
         *
         * @param   regex
         *          the regular expression to which this string is to be matched
         * @param   replacement
         *          the string to be substituted for the first match
         *
         * @return  The resulting <tt>String</tt>
         *
         * @throws  PatternSyntaxException
         *          if the regular expression's syntax is invalid
         *
         * @see java.util.regex.Pattern
         *
         * @since 1.4
         * @spec JSR-51
         */
        public static string ReplaceFirst(this string s, string regex, string replacement)
        {
            Regex r = new Regex(regex);
            return r.Replace(s, replacement, 1);
        }

        /**
         * Replaces each substring of this string that matches the given <a
         * href="../util/regex/Pattern.html#sum">regular expression</a> with the
         * given replacement.
         *
         * <p> An invocation of this method of the form
         * <i>str</i><tt>.replaceAll(</tt><i>regex</i><tt>,</tt> <i>repl</i><tt>)</tt>
         * yields exactly the same result as the expression
         *
         * <blockquote><tt>
         * {@link java.util.regex.Pattern}.{@link java.util.regex.Pattern#compile
         * compile}(</tt><i>regex</i><tt>).{@link
         * java.util.regex.Pattern#matcher(java.lang.CharSequence)
         * matcher}(</tt><i>str</i><tt>).{@link java.util.regex.Matcher#replaceAll
         * replaceAll}(</tt><i>repl</i><tt>)</tt></blockquote>
         *
         *<p>
         * Note that backslashes (<tt>\</tt>) and dollar signs (<tt>$</tt>) in the
         * replacement string may cause the results to be different than if it were
         * being treated as a literal replacement string; see
         * {@link java.util.regex.Matcher#replaceAll Matcher.replaceAll}.
         * Use {@link java.util.regex.Matcher#quoteReplacement} to suppress the special
         * meaning of these characters, if desired.
         *
         * @param   regex
         *          the regular expression to which this string is to be matched
         * @param   replacement
         *          the string to be substituted for each match
         *
         * @return  The resulting <tt>String</tt>
         *
         * @throws  PatternSyntaxException
         *          if the regular expression's syntax is invalid
         *
         * @see java.util.regex.Pattern
         *
         * @since 1.4
         * @spec JSR-51
         */
        public static string ReplaceAll(this string s, string regex, string replacement)
        {
            return Regex.Replace(s, regex, replacement);
        }

        // * replace is already implemented.

        /**
         * Splits this string around matches of the given
         * <a href="../util/regex/Pattern.html#sum">regular expression</a>.
         *
         * <p> The array returned by this method contains each substring of this
         * string that is terminated by another substring that matches the given
         * expression or is terminated by the end of the string.  The substrings in
         * the array are in the order in which they occur in this string.  If the
         * expression does not match any part of the input then the resulting array
         * has just one element, namely this string.
         *
         * <p> The <tt>limit</tt> parameter controls the number of times the
         * pattern is applied and therefore affects the length of the resulting
         * array.  If the limit <i>n</i> is greater than zero then the pattern
         * will be applied at most <i>n</i>&nbsp;-&nbsp;1 times, the array's
         * length will be no greater than <i>n</i>, and the array's last entry
         * will contain all input beyond the last matched delimiter.  If <i>n</i>
         * is non-positive then the pattern will be applied as many times as
         * possible and the array can have any length.  If <i>n</i> is zero then
         * the pattern will be applied as many times as possible, the array can
         * have any length, and trailing empty strings will be discarded.
         *
         * <p> The string <tt>"boo:and:foo"</tt>, for example, yields the
         * following results with these parameters:
         *
         * <blockquote><table cellpadding=1 cellspacing=0 summary="Split example showing regex, limit, and result">
         * <tr>
         *     <th>Regex</th>
         *     <th>Limit</th>
         *     <th>Result</th>
         * </tr>
         * <tr><td align=center>:</td>
         *     <td align=center>2</td>
         *     <td><tt>{ "boo", "and:foo" }</tt></td></tr>
         * <tr><td align=center>:</td>
         *     <td align=center>5</td>
         *     <td><tt>{ "boo", "and", "foo" }</tt></td></tr>
         * <tr><td align=center>:</td>
         *     <td align=center>-2</td>
         *     <td><tt>{ "boo", "and", "foo" }</tt></td></tr>
         * <tr><td align=center>o</td>
         *     <td align=center>5</td>
         *     <td><tt>{ "b", "", ":and:f", "", "" }</tt></td></tr>
         * <tr><td align=center>o</td>
         *     <td align=center>-2</td>
         *     <td><tt>{ "b", "", ":and:f", "", "" }</tt></td></tr>
         * <tr><td align=center>o</td>
         *     <td align=center>0</td>
         *     <td><tt>{ "b", "", ":and:f" }</tt></td></tr>
         * </table></blockquote>
         *
         * <p> An invocation of this method of the form
         * <i>str.</i><tt>split(</tt><i>regex</i><tt>,</tt>&nbsp;<i>n</i><tt>)</tt>
         * yields the same result as the expression
         *
         * <blockquote>
         * {@link java.util.regex.Pattern}.{@link java.util.regex.Pattern#compile
         * compile}<tt>(</tt><i>regex</i><tt>)</tt>.{@link
         * java.util.regex.Pattern#split(java.lang.CharSequence,int)
         * split}<tt>(</tt><i>str</i><tt>,</tt>&nbsp;<i>n</i><tt>)</tt>
         * </blockquote>
         *
         *
         * @param  regex
         *         the delimiting regular expression
         *
         * @param  limit
         *         the result threshold, as described above
         *
         * @return  the array of strings computed by splitting this string
         *          around matches of the given regular expression
         *
         * @throws  PatternSyntaxException
         *          if the regular expression's syntax is invalid
         *
         * @see java.util.regex.Pattern
         *
         * @since 1.4
         * @spec JSR-51
         */
        public static string[] Split(this string s, string regex, int limit)
        {
            Regex r = new Regex(regex);
            return r.Split(s, limit, 0);
        }

        /**
         * Splits this string around matches of the given <a
         * href="../util/regex/Pattern.html#sum">regular expression</a>.
         *
         * <p> This method works as if by invoking the two-argument {@link
         * #split(String, int) split} method with the given expression and a limit
         * argument of zero.  Trailing empty strings are therefore not included in
         * the resulting array.
         *
         * <p> The string <tt>"boo:and:foo"</tt>, for example, yields the following
         * results with these expressions:
         *
         * <blockquote><table cellpadding=1 cellspacing=0 summary="Split examples showing regex and result">
         * <tr>
         *  <th>Regex</th>
         *  <th>Result</th>
         * </tr>
         * <tr><td align=center>:</td>
         *     <td><tt>{ "boo", "and", "foo" }</tt></td></tr>
         * <tr><td align=center>o</td>
         *     <td><tt>{ "b", "", ":and:f" }</tt></td></tr>
         * </table></blockquote>
         *
         *
         * @param  regex
         *         the delimiting regular expression
         *
         * @return  the array of strings computed by splitting this string
         *          around matches of the given regular expression
         *
         * @throws  PatternSyntaxException
         *          if the regular expression's syntax is invalid
         *
         * @see java.util.regex.Pattern
         *
         * @since 1.4
         * @spec JSR-51
         */
        public static string[] Split(this string s, string regex)
        {
            return Regex.Split(s, regex);
        }

        /**
         * Converts all of the characters in this <code>String</code> to lower
         * case using the rules of the given <code>Locale</code>.  Case mapping is based
         * on the Unicode Standard version specified by the {@link java.lang.Character Character}
         * class. Since case mappings are not always 1:1 char mappings, the resulting
         * <code>String</code> may be a different length than the original <code>String</code>.
         * <p>
         * Examples of lowercase  mappings are in the following table:
         * <table border="1" summary="Lowercase mapping examples showing language code of locale, upper case, lower case, and description">
         * <tr>
         *   <th>Language Code of Locale</th>
         *   <th>Upper Case</th>
         *   <th>Lower Case</th>
         *   <th>Description</th>
         * </tr>
         * <tr>
         *   <td>tr (Turkish)</td>
         *   <td>&#92;u0130</td>
         *   <td>&#92;u0069</td>
         *   <td>capital letter I with dot above -&gt; small letter i</td>
         * </tr>
         * <tr>
         *   <td>tr (Turkish)</td>
         *   <td>&#92;u0049</td>
         *   <td>&#92;u0131</td>
         *   <td>capital letter I -&gt; small letter dotless i </td>
         * </tr>
         * <tr>
         *   <td>(all)</td>
         *   <td>French Fries</td>
         *   <td>french fries</td>
         *   <td>lowercased all chars in String</td>
         * </tr>
         * <tr>
         *   <td>(all)</td>
         *   <td><img src="doc-files/capiota.gif" alt="capiota"><img src="doc-files/capchi.gif" alt="capchi">
         *       <img src="doc-files/captheta.gif" alt="captheta"><img src="doc-files/capupsil.gif" alt="capupsil">
         *       <img src="doc-files/capsigma.gif" alt="capsigma"></td>
         *   <td><img src="doc-files/iota.gif" alt="iota"><img src="doc-files/chi.gif" alt="chi">
         *       <img src="doc-files/theta.gif" alt="theta"><img src="doc-files/upsilon.gif" alt="upsilon">
         *       <img src="doc-files/sigma1.gif" alt="sigma"></td>
         *   <td>lowercased all chars in String</td>
         * </tr>
         * </table>
         *
         * @param locale use the case transformation rules for this locale
         * @return the <code>String</code>, converted to lowercase.
         * @see     java.lang.String#toLowerCase()
         * @see     java.lang.String#toUpperCase()
         * @see     java.lang.String#toUpperCase(Locale)
         * @since   1.1
         */
        public static string ToLowerCase(this string s, CultureInfo locale)
        {
            return s.ToLower(locale);
        }

        /**
         * Converts all of the characters in this <code>String</code> to lower
         * case using the rules of the default locale. This is equivalent to calling
         * <code>toLowerCase(Locale.getDefault())</code>.
         * <p>
         * <b>Note:</b> This method is locale sensitive, and may produce unexpected
         * results if used for strings that are intended to be interpreted locale
         * independently.
         * Examples are programming language identifiers, protocol keys, and HTML
         * tags.
         * For instance, <code>"TITLE".toLowerCase()</code> in a Turkish locale
         * returns <code>"t\u0131tle"</code>, where '\u0131' is the LATIN SMALL
         * LETTER DOTLESS I character.
         * To obtain correct results for locale insensitive strings, use
         * <code>toLowerCase(Locale.ENGLISH)</code>.
         * <p>
         * @return  the <code>String</code>, converted to lowercase.
         * @see     java.lang.String#toLowerCase(Locale)
         */
        public static string ToLowerCase(this string s)
        {
            return s.ToLower();
        }

        /**
         * Converts all of the characters in this <code>String</code> to upper
         * case using the rules of the given <code>Locale</code>. Case mapping is based
         * on the Unicode Standard version specified by the {@link java.lang.Character Character}
         * class. Since case mappings are not always 1:1 char mappings, the resulting
         * <code>String</code> may be a different length than the original <code>String</code>.
         * <p>
         * Examples of locale-sensitive and 1:M case mappings are in the following table.
         * <p>
         * <table border="1" summary="Examples of locale-sensitive and 1:M case mappings. Shows Language code of locale, lower case, upper case, and description.">
         * <tr>
         *   <th>Language Code of Locale</th>
         *   <th>Lower Case</th>
         *   <th>Upper Case</th>
         *   <th>Description</th>
         * </tr>
         * <tr>
         *   <td>tr (Turkish)</td>
         *   <td>&#92;u0069</td>
         *   <td>&#92;u0130</td>
         *   <td>small letter i -&gt; capital letter I with dot above</td>
         * </tr>
         * <tr>
         *   <td>tr (Turkish)</td>
         *   <td>&#92;u0131</td>
         *   <td>&#92;u0049</td>
         *   <td>small letter dotless i -&gt; capital letter I</td>
         * </tr>
         * <tr>
         *   <td>(all)</td>
         *   <td>&#92;u00df</td>
         *   <td>&#92;u0053 &#92;u0053</td>
         *   <td>small letter sharp s -&gt; two letters: SS</td>
         * </tr>
         * <tr>
         *   <td>(all)</td>
         *   <td>Fahrvergn&uuml;gen</td>
         *   <td>FAHRVERGN&Uuml;GEN</td>
         *   <td></td>
         * </tr>
         * </table>
         * @param locale use the case transformation rules for this locale
         * @return the <code>String</code>, converted to uppercase.
         * @see     java.lang.String#toUpperCase()
         * @see     java.lang.String#toLowerCase()
         * @see     java.lang.String#toLowerCase(Locale)
         * @since   1.1
         */
        public static string ToUpperCase(this string s, CultureInfo locale)
        {
            return s.ToUpper(locale);
        }

        /**
         * Converts all of the characters in this <code>String</code> to upper
         * case using the rules of the default locale. This method is equivalent to
         * <code>toUpperCase(Locale.getDefault())</code>.
         * <p>
         * <b>Note:</b> This method is locale sensitive, and may produce unexpected
         * results if used for strings that are intended to be interpreted locale
         * independently.
         * Examples are programming language identifiers, protocol keys, and HTML
         * tags.
         * For instance, <code>"title".toUpperCase()</code> in a Turkish locale
         * returns <code>"T\u0130TLE"</code>, where '\u0130' is the LATIN CAPITAL
         * LETTER I WITH DOT ABOVE character.
         * To obtain correct results for locale insensitive strings, use
         * <code>toUpperCase(Locale.ENGLISH)</code>.
         * <p>
         * @return  the <code>String</code>, converted to uppercase.
         * @see     java.lang.String#toUpperCase(Locale)
         */
        public static string ToUpperCase(this string s)
        {
            return s.ToUpper();
        }

        // * trim is already implemented.
        // * toString is already implemented.
        // * toCharArray is already implemented.
        // * format is already implemented.

        /**
         * Returns the string representation of the <code>Object</code> argument.
         *
         * @param   obj   an <code>Object</code>.
         * @return  if the argument is <code>null</code>, then a string equal to
         *          <code>"null"</code>; otherwise, the value of
         *          <code>obj.toString()</code> is returned.
         * @see     java.lang.Object#toString()
         */
        public static string ValueOf(Object obj)
        {
            return (obj == null) ? "null" : obj.ToString();
        }

        /**
         * Returns the string representation of the <code>char</code> array
         * argument. The contents of the character array are copied; subsequent
         * modification of the character array does not affect the newly
         * created string.
         *
         * @param   data   a <code>char</code> array.
         * @return  a newly allocated string representing the same sequence of
         *          characters contained in the character array argument.
         */
        public static string ValueOf(char[] data)
        {
            return new String(data);
        }

        /**
         * Returns the string representation of a specific subarray of the
         * <code>char</code> array argument.
         * <p>
         * The <code>offset</code> argument is the index of the first
         * character of the subarray. The <code>count</code> argument
         * specifies the length of the subarray. The contents of the subarray
         * are copied; subsequent modification of the character array does not
         * affect the newly created string.
         *
         * @param   data     the character array.
         * @param   offset   the initial offset into the value of the
         *                  <code>String</code>.
         * @param   count    the length of the value of the <code>String</code>.
         * @return  a string representing the sequence of characters contained
         *          in the subarray of the character array argument.
         * @exception IndexOutOfBoundsException if <code>offset</code> is
         *          negative, or <code>count</code> is negative, or
         *          <code>offset+count</code> is larger than
         *          <code>data.length</code>.
         */
        public static string ValueOf(char[] data, int offset, int count)
        {
            return new String(data, offset, count);
        }

        /**
         * Returns a String that represents the character sequence in the
         * array specified.
         *
         * @param   data     the character array.
         * @param   offset   initial offset of the subarray.
         * @param   count    length of the subarray.
         * @return  a <code>String</code> that contains the characters of the
         *          specified subarray of the character array.
         */
        public static string CopyValueOf(char[] data, int offset, int count)
        {
            return new String(data, offset, count);
        }

        /**
         * Returns a String that represents the character sequence in the
         * array specified.
         *
         * @param   data   the character array.
         * @return  a <code>String</code> that contains the characters of the
         *          character array.
         */
        public static string CopyValueOf(char[] data)
        {
            return new String(data, 0, data.Length);
        }

        /**
         * Returns the string representation of the <code>boolean</code> argument.
         *
         * @param   b   a <code>boolean</code>.
         * @return  if the argument is <code>true</code>, a string equal to
         *          <code>"true"</code> is returned; otherwise, a string equal to
         *          <code>"false"</code> is returned.
         */
        public static string ValueOf(bool b)
        {
            return b ? "true" : "false";
        }

        /**
         * Returns the string representation of the <code>char</code>
         * argument.
         *
         * @param   c   a <code>char</code>.
         * @return  a string of length <code>1</code> containing
         *          as its single character the argument <code>c</code>.
         */
        public static string ValueOf(char c)
        {
            return new String(new char[] { c }, 0, 1);
        }

        /**
         * Returns the string representation of the <code>int</code> argument.
         * <p>
         * The representation is exactly the one returned by the
         * <code>Integer.toString</code> method of one argument.
         *
         * @param   i   an <code>int</code>.
         * @return  a string representation of the <code>int</code> argument.
         * @see     java.lang.Integer#toString(int, int)
         */
        public static string ValueOf(int i)
        {
            return i.ToString();
        }

        /**
         * Returns the string representation of the <code>long</code> argument.
         * <p>
         * The representation is exactly the one returned by the
         * <code>Long.toString</code> method of one argument.
         *
         * @param   l   a <code>long</code>.
         * @return  a string representation of the <code>long</code> argument.
         * @see     java.lang.Long#toString(long)
         */
        public static string ValueOf(long l)
        {
            return l.ToString();
        }

        /**
         * Returns the string representation of the <code>float</code> argument.
         * <p>
         * The representation is exactly the one returned by the
         * <code>Float.toString</code> method of one argument.
         *
         * @param   f   a <code>float</code>.
         * @return  a string representation of the <code>float</code> argument.
         * @see     java.lang.Float#toString(float)
         */
        public static string ValueOf(float f)
        {
            return f.ToString();
        }

        /**
         * Returns the string representation of the <code>double</code> argument.
         * <p>
         * The representation is exactly the one returned by the
         * <code>Double.toString</code> method of one argument.
         *
         * @param   d   a <code>double</code>.
         * @return  a  string representation of the <code>double</code> argument.
         * @see     java.lang.Double#toString(double)
         */
        public static string ValueOf(double d)
        {
            return d.ToString();
        }
    }
}
