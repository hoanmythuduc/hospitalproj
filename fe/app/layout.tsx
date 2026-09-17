import localFont from 'next/font/local';
import './globals.css';
import { Metadata } from 'next';

const centuryGothic = localFont({
  src: [
    { path: '../public/fonts/CenturyGothic-Thin.otf', weight: '100', style: 'normal' },
    { path: '../public/fonts/CenturyGothic-Light.otf', weight: '300', style: 'normal' },
    { path: '../public/fonts/CenturyGothic-Regular.otf', weight: '400', style: 'normal' },
    { path: '../public/fonts/CenturyGothic-SemiBold.otf', weight: '600', style: 'normal' },
    { path: '../public/fonts/CenturyGothic-Bold.otf', weight: '700', style: 'normal' },
    { path: '../public/fonts/CenturyGothic-ExtraBold.otf', weight: '800', style: 'normal' },
    { path: '../public/fonts/CenturyGothic-Black.otf', weight: '900', style: 'normal' },
  ],
  variable: '--font-century-gothic',
  display: 'swap',
});

export const metadata = {
  title: 'Hehe',
  description: 'hehe',
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en" className={`${centuryGothic.variable} antialiased font-sans`}>
      <body>
        {children}
      </body>
    </html>
  );
}