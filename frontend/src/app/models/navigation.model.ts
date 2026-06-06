export interface NavItem {
  label: string;
  icon: string;
  route: string;
}

export interface KpiData {
  title: string;
  value: string | number;
  icon: string;
  trend?: string;
  accentColor?: string;
}
