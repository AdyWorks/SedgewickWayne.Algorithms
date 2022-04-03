﻿namespace SedgewickWayne.Algorithms.PerformanceTests;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

internal static class StreamExtensions
{
	public static async Task CopyToDestinationStreamWithProgressAsync(
		this Stream source,
		Stream destination,
		int bufferSize,
		IProgress<long> progress = null,
		CancellationToken cancellationToken = default(CancellationToken))
	{
		if (bufferSize < 0)
			throw new ArgumentOutOfRangeException(nameof(bufferSize));
		if (source is null)
			throw new ArgumentNullException(nameof(source));
		if (!source.CanRead)
			throw new InvalidOperationException($"'{nameof(source)}' is not readable.");
		if (destination == null)
			throw new ArgumentNullException(nameof(destination));
		if (!destination.CanWrite)
			throw new InvalidOperationException($"'{nameof(destination)}' is not writable.");

		var buffer = new byte[bufferSize];
		long totalBytesRead = 0;
		int bytesRead;
		while ((bytesRead = await source.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) != 0)
		{
			await destination.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
			totalBytesRead += bytesRead;
			progress?.Report(totalBytesRead);
		}
	}
}
