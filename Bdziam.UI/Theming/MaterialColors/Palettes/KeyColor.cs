using Bdziam.UI.Theming.MaterialColors.ColorSpace;

namespace Bdziam.UI.Theming.MaterialColors.Palettes;
  /** Key color is a color that represents the hue and chroma of a tonal palette. */
  
  public sealed class KeyColor {
    public double Hue { get; protected set; }
    private double RequestedChroma { get; set; }

    // Cache that maps tone to max chroma to avoid duplicated HCT calculation.
    private Dictionary<uint, Double> chromaCache = new ();
    private const double MAX_CHROMA_VALUE = 200.0;

    /** Key color is a color that represents the hue and chroma of a tonal palette */
    public KeyColor(double hue, double requestedChroma) {
      this.Hue = hue; 
      this.RequestedChroma = requestedChroma;
    }

    /**
     * Creates a key color from a [hue] and a [chroma]. The key color is the first tone, starting
     * from T50, matching the given hue and chroma.
     *
     * @return Key color [Hct]
     */
    public Hct Create() {
      // Pivot around T50 because T50 has the most chroma available, on
      // average. Thus it is most likely to have a direct answer.
      uint pivotTone = 50;
      uint toneStepSize = 1;
      // Epsilon to accept values slightly higher than the requested chroma.
      double epsilon = 0.01;

      // Binary search to find the tone that can provide a chroma that is closest
      // to the requested chroma.
      uint lowerTone = 0;
      uint upperTone = 100;
      while (lowerTone < upperTone) { 
        uint midTone = (lowerTone + upperTone) / 2;
        bool isAscending = maxChroma(midTone) < maxChroma(midTone + toneStepSize);
        bool sufficientChroma = maxChroma(midTone) >= RequestedChroma - epsilon;

        if (sufficientChroma) {
          // Either range [lowerTone, midTone] or [midTone, upperTone] has
          // the answer, so search in the range that is closer the pivot tone.
          if (Math.Abs(lowerTone - pivotTone) < Math.Abs(upperTone - pivotTone)) {
            upperTone = midTone;
          } else {
            if (lowerTone == midTone) {
              return Hct.From(this.Hue, this.RequestedChroma, lowerTone);
            }
            lowerTone = midTone;
          }
        } else {
          // As there is no sufficient chroma in the midTone, follow the direction to the chroma
          // peak.
          if (isAscending) {
            lowerTone = midTone + toneStepSize;
          } else {
            // Keep midTone for potential chroma peak.
            upperTone = midTone;
          }
        }
      }

      return Hct.From(this.Hue, this.RequestedChroma, lowerTone);
    }

    // Find the maximum chroma for a given tone
    private double maxChroma(uint tone) {
      if (!chromaCache.TryGetValue(tone, out var chroma)) {
        Double newChroma = Hct.From(Hue, MAX_CHROMA_VALUE, tone).Chroma;
        chromaCache.Add(tone, newChroma);
      }
      return chromaCache[tone];
    }
  }