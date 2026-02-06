interface TimelineItem {
  id: string;
  target: string;
  from?: { [key: string]: any }; // Generic object
  to: { [key: string]: any };
  duration: number;
  repeat?: number;
  yoyo?: boolean;
  ease?: string;
  delay?: number;
  stagger?: number;
}

export interface AnimationSpec {
  timeline: TimelineItem[];
  elements: Array<{
    id: string;
    className: string;
    style?: React.CSSProperties;
  }>;
  layout: string;
  background: string;
}
