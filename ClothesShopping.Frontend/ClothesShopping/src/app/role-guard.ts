// role.guard.ts
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class RoleGuard implements CanActivate {
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const expectedRole = (route.data as any).expectedRole;
    const userRole = localStorage.getItem('userRol');

    if (userRole && userRole === expectedRole) {
      return true;
    }
    this.router.navigate(['/products']);
    return false;
  }

  constructor(private router: Router) {}
}
